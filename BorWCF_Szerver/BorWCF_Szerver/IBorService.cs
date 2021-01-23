using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BorWCF_Szerver
{
    [ServiceContract]
    public interface IBorService
    {
        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        string getUsername(int id);

        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        string Login(string name, string password);

        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        string Logout(string id);

        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        string Add(string fajta, int alkohol, string cukor, string user);

        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        List<Bor> List();

        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        string Update(int id, string fajta, int alkohol, string cukor, string user);

        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        string Delete(int borId, string user);

        [OperationContract]
        [FaultContract(typeof(FaultContract))]
        FaultContract Connection();
    }

    [DataContract]
    public class Bor
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string fajta;
        [DataMember]
        public string Fajta
        {
            get { return fajta; }
            set { fajta = value; }
        }

        private int alkohol;
        [DataMember]
        public int Alkohol
        {
            get { return alkohol; }
            set { alkohol = value; }
        }

        private string cukor;
        [DataMember]
        public string Cukor
        {
            get { return cukor; }
            set { cukor = value; }
        }

        private int user_id;
        [DataMember]
        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public Bor(int id, string fajta, int alkohol, string cukor, int user_id)
        {
            this.id = id;
            this.fajta = fajta;
            this.alkohol = alkohol;
            this.cukor = cukor;
            this.user_id = user_id;
        }
    }

    [DataContract]
    public class User
    {
        string name = null;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id;
        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string password;
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User(string name, int id, string password)
        {
            this.name = name;
            this.id = id;
            this.password = password;
        }
    }

    [DataContract]
    public class FaultContract
    {
        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
