using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace BorWCF_Szerver
{
    public class BorService : IBorService
    {
        static MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "root",
                Port = 3308,
                Database = "borok"
            };
        private static MySqlConnection conn = new MySqlConnection(build.ToString());

        
        public static List<Bor> borok = new List<Bor>();
        static Dictionary<string, string> logged = new Dictionary<string, string>();

        public FaultContract Connection()
        {
            FaultContract fault = new FaultContract();
            try
            {
                conn.Open();
                fault.Result = true;
                conn.Close();
                return fault;
            }
            catch (MySqlException sqlEx)
            {
                fault.Result = false;
                fault.Message = "A csatlakozás nem sikerült";
                fault.Description = sqlEx.ToString();
                throw new FaultException<FaultContract>(fault, sqlEx.ToString());
            }
            catch (Exception ex)
            {
                fault.Result = false;
                fault.Message = "Ismeretlen hiba";
                fault.Description = ex.ToString();
                throw new FaultException<FaultContract>(fault, ex.ToString());
            }
        }

        public string getUsername(int id)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (id.ToString() == reader["id"].ToString())
                    {
                        string name = reader["name"].ToString();
                        reader.Close();
                        conn.Close();
                        return name;
                    }
                }
                reader.Close();
                conn.Close();
                return "Nincs felhasználó";
            }
            catch (MySqlException ex)
            {
                FaultContract loginerr = new FaultContract();
                loginerr.Result = false;
                loginerr.Message = "Nem megfelelő felhasználó adatok";
                loginerr.Description = ex.Message;
                throw new FaultException<FaultContract>(loginerr);
            }
            catch (Exception ex)
            {
                FaultContract err = new FaultContract();
                err.Result = false;
                err.Message = "Hiba a név lekérésnél";
                err.Description = ex.Message;
                throw new FaultException<FaultContract>(err);
            }

        }
        public string Login(string name, string password)
        {
            try
            {
                if (name == null || name == "" || password == null || password == "")
                {
                    return null;

                }
                else
                {
                    conn.Open();
                    string query = "SELECT * FROM users";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (name == reader["name"].ToString())
                        {
                            if (password == reader["password"].ToString())
                            {
                                string id = reader["id"].ToString();
                                logged.Add(id, name);
                                reader.Close();
                                conn.Close();
                                return id;
                            }
                        }
                    }
                    reader.Close();
                    conn.Close();
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                FaultContract loginerr = new FaultContract();
                loginerr.Result = false;
                loginerr.Message = "Nem megfelelő belépési adatok";
                loginerr.Description = ex.Message;
                throw new FaultException<FaultContract>(loginerr);
            }
            catch (Exception ex)
            {
                FaultContract err = new FaultContract();
                err.Result = false;
                err.Message = "Hiba a belépésnél";
                err.Description = ex.Message;
                throw new FaultException<FaultContract>(err);
            }
        }

        public string Logout(string id)
        {
            if (id == null)
            {
                return "Nem vagy belépve";
            }
            else
            {
                try
                {
                    foreach (KeyValuePair<string, string> userId in logged)
                    {
                        if (userId.Key == id)
                        {
                            logged.Remove(userId.Key);
                            return "Sikeresen kilépve";
                        }
                    }
                    return "Hiba";
                }
                catch (Exception ex)
                {
                    FaultContract err = new FaultContract();
                    err.Result = false;
                    err.Message = "Hiba a kilépésnél";
                    err.Description = ex.Message;
                    throw new FaultException<FaultContract>(err);
                }
            }
        }
        
        public string Add(string fajta, int alkohol, string cukor, string user)
        {
            if (user == null || !logged.ContainsKey(user))
            {
                return "Be kell jelentkezni";
            }
            else if (fajta == "" || cukor == "")
            {
                return "Hiányos adatok";
            }
            else if (alkohol < 0)
            {
                return "Nem lehet negatív szám";
            }
            else
            {
                lock (borok)
                {
                    borok.Clear();
                    this.List();
                    foreach (Bor item in borok)
                    {
                        if (fajta == item.Fajta && alkohol == item.Alkohol && cukor == item.Cukor)
                        {
                            return "Már létezik ugyanilyen bor";
                        }
                    }
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO bor (fajta, alkohol, cukor, felvivo_id) VALUES (\""+fajta+ "\"," + alkohol + ",\"" + cukor + "\"," + int.Parse(user) + ")";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();

                        borok.Add(new Bor(borok.Last<Bor>().Id + 1, fajta, alkohol, cukor, int.Parse(user)));
                        conn.Close();
                        return "Bor hozzáadva";
                    }
                    catch (MySqlException ex)
                    {
                        FaultContract insert = new FaultContract();
                        insert.Result = false;
                        insert.Message = ex.Message;
                        insert.Description = "A bevitt adatok valamelyike hibás";
                        throw new FaultException<FaultContract>(insert);
                    }
                    catch (Exception ex)
                    {
                        FaultContract err = new FaultContract();
                        err.Result = false;
                        err.Message = ex.Message;
                        err.Description = "A bevitt adatok valamelyike hibás";
                        throw new FaultException<FaultContract>(err);
                    }
                }
            }
        }

        public List<Bor> List()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM bor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                lock (borok)
                {
                    borok.Clear();
                    while (reader.Read())
                    {
                        
                        int id = Convert.ToInt16(reader["id"]);
                        string fajta = reader["fajta"].ToString();
                        int alkohol = Convert.ToInt16(reader["alkohol"]);
                        string cukor = reader["cukor"].ToString();
                        int user_id = Convert.ToInt16(reader["felvivo_id"]);

                        borok.Add(new Bor(id, fajta, alkohol, cukor, user_id));
                    }
                    reader.Close();
                    conn.Close();
                    return borok;
                }
            }
            catch (MySqlException ex)
            {
                FaultContract list = new FaultContract();
                list.Result = false;
                list.Description = "Lekérési hiba";
                list.Message = ex.Message;
                throw new FaultException<FaultContract>(list);
            }
        }
        public string Update(int id, string fajta, int alkohol, string cukor, string user)
        {
            if (user == null || !logged.ContainsKey(user))
            {
                return "Be kell jelentkezni";
            }
            else if (fajta == "" || cukor == "")
            {
                return "Hiányos adatok";
            }
            else if (alkohol < 0)
            {
                return "Nem lehet negatív szám";
            }
            else
            {
                lock (borok)
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE bor SET fajta = \"" + fajta + "\" ,alkohol = "+alkohol+ " ,cukor = \""+cukor+"\" WHERE id = "+id;
                        MySqlCommand cmd = new MySqlCommand(query,conn);
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (rows == 0)
                        {
                            return "A módosítás sikertelen volt";
                        }
                        else
                        {
                            return "Sikeres volt a módosítás";
                        }
                    }
                    catch (MySqlException ex)
                    {
                        FaultContract delete = new FaultContract();
                        delete.Result = false;
                        delete.Message = ex.Message;
                        delete.Description = "Módosítási hiba";
                        throw new FaultException<FaultContract>(delete);
                    }
                    catch (Exception ex)
                    {
                        FaultContract error = new FaultContract();
                        error.Result = false;
                        error.Message = "Ismeretlen hiba";
                        error.Description = ex.ToString();
                        throw new FaultException<FaultContract>(error);
                    }
                }
            }
        }

        public string Delete(int id, string user)
        {
            if (user == null || !logged.ContainsKey(user))
            {
                return "Be kell jelentkezni";
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM bor WHERE id = " + id;
                    lock (borok)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();
                        this.List();
                        if (rows == 0)
                            return "Törlés nem sikerült";
                        else
                            return "Sikeres törlés";
                    }
                }
                catch (MySqlException ex)
                {
                    FaultContract delete = new FaultContract();
                    delete.Result = false;
                    delete.Description = ex.Message;
                    delete.Message = "Törlési hiba!";
                    throw new FaultException<FaultContract>(delete);
                }
                catch (Exception ex)
                {
                    FaultContract error = new FaultContract();
                    error.Result = false;
                    error.Message = "Ismeretlen hiba";
                    error.Description = ex.ToString();
                    throw new FaultException<FaultContract>(error);
                }
            }
        } 
    }
}
