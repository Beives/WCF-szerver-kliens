using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using BorWCF_Kliens.BorServiceReference;

namespace BorWCF_Kliens
{
    public partial class Form1 : Form
    {
        BorServiceClient client = new BorServiceClient();
        string userId = null;
        int borId;
        List<Bor> borresult = new List<Bor>();
        public Form1()
        {
            InitializeComponent();
            try
            {
                FaultContract serviceData = client.Connection();
                if (serviceData.Result)
                {
                    csatlLabel.Text="Csatlakozva az adatbázishoz";
                    loginpassTxtbox.PasswordChar = '*';
                    logoutBtn.Visible = false;
                    fajtaTxtbox.Enabled = false;
                    alkoholNumeric.Enabled = false;
                    edessegTxtbox.Enabled = false;
                    felvitelBtn.Enabled = false;
                    modositBtn.Enabled = false;
                    borGrid.Enabled = false;
                    modositBtn.Visible = false;
                    LoadGrid();
                    FillGrid();
                }
            }
            catch (FaultException<FaultContract> fault)
            {
                MessageBox.Show("ErrorMessage:" + fault.Detail.Message,"Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("ErrorDetails::" + fault.Detail.Description,"Hiba",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            csatlLabel.Text = "";
        }

        private void LoadGrid()
        {
            borGrid.Columns.Clear();
            borGrid.AllowUserToAddRows = false;
            borGrid.AllowUserToDeleteRows = false;
            borGrid.AllowUserToOrderColumns = true;
            borGrid.ReadOnly = true;
            borGrid.Columns.Add("id", "Bor id");
            borGrid.Columns.Add("alkohol", "Alkohol");
            borGrid.Columns.Add("fajta", "Fajta");
            borGrid.Columns.Add("cukor", "Édesség");
            borGrid.Columns.Add("felvivo", "Felvitte");


            DataGridViewButtonColumn set = new DataGridViewButtonColumn();
            set.Text = "Modosit";
            set.Name = "Modosit";
            set.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.Text = "Torles";
            del.Name = "Torles";
            del.UseColumnTextForButtonValue = true;

            borGrid.Columns.Add(set);
            borGrid.Columns.Add(del);
            borGrid.AutoResizeColumns();
        }

        private void FillGrid()
        {
            try
            {
                borresult = client.List().ToList<Bor>();
                borGrid.Rows.Clear();
                borGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                borGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                foreach (Bor bor in borresult)
                {
                    borGrid.Rows.Add(bor.Id, bor.Alkohol, bor.Fajta, bor.Cukor, client.getUsername(bor.User_id));
                }
            }
            catch (FaultException<FaultException> ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (felvitelBtn.Enabled == true)
            {
                base.OnFormClosing(e);
                string message = client.Logout(userId);
                MessageBox.Show(message);
            }
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                userId = client.Login(loginnameTxtbox.Text, loginpassTxtbox.Text);
                if (userId != null)
                {
                    loginpassTxtbox.Visible = false;
                    loginpassTxtbox.Clear();
                    loginnameTxtbox.Visible = false;
                    loginnameTxtbox.Clear();
                    loginBtn.Visible = false;
                    jelszoLabel.Visible = false;
                    nevLabel.Visible = false;
                    loginLabel.Visible = false;
                    logindefpass.Visible = false;
                    logindefname.Visible = false;

                    logoutBtn.Visible = true;
                    fajtaTxtbox.Enabled = true;
                    alkoholNumeric.Enabled = true;
                    edessegTxtbox.Enabled = true;
                    felvitelBtn.Enabled = true;
                    modositBtn.Enabled = true;
                    borGrid.Enabled = true;

                    FillGrid();
                }
                else
                    MessageBox.Show("Sikertelen bejelentkezés", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException<FaultException> ex)
            {
                MessageBox.Show(ex.Message, "LOGIN", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void listaBtn_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            string result = client.Logout(userId);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loginpassTxtbox.Visible = true;
            loginnameTxtbox.Visible = true;
            loginBtn.Visible = true;
            jelszoLabel.Visible = true;
            nevLabel.Visible = true;
            loginLabel.Visible = true;

            logoutBtn.Visible = false;
            fajtaTxtbox.Enabled = false;
            alkoholNumeric.Enabled = false;
            edessegTxtbox.Enabled = false;
            felvitelBtn.Enabled = false;
            modositBtn.Enabled = false;
            borGrid.Enabled = false;
        }

        private void felvitelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)alkoholNumeric.Value < 0)
                {
                    MessageBox.Show("Nem lehet 0 alatti az alkohol", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string result = client.Add(fajtaTxtbox.Text, (int)alkoholNumeric.Value, edessegTxtbox.Text, userId);
                    MessageBox.Show(result, "Eredmény", MessageBoxButtons.OK);
                    if (result == "Bor hozzáadva")
                    {
                        fajtaTxtbox.Clear();
                        alkoholNumeric.Value = 0;
                        edessegTxtbox.Clear();
                        FillGrid();
                    }
                }
            }
            catch (FaultException<FaultException> ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void modositBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)alkoholNumeric.Value < 0)
                    MessageBox.Show("Nem lehet 0 alatti az alkohol", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string result = client.Update(borId, fajtaTxtbox.Text, (int)alkoholNumeric.Value, edessegTxtbox.Text, userId);
                    MessageBox.Show(result, "Eredmény", MessageBoxButtons.OK);

                    modositBtn.Visible = false;
                    felvitelBtn.Enabled = true;
                    borGrid.Enabled = true;
                    fajtaTxtbox.Clear();
                    alkoholNumeric.Value = 0;
                    edessegTxtbox.Clear();
                    FillGrid();
                }
            }
            catch (FaultException<FaultException> ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void borGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            switch (view.Columns[e.ColumnIndex].Name)
            {
                case "Modosit":
                    fajtaTxtbox.Text = view.Rows[e.RowIndex].Cells["fajta"].Value.ToString();
                    edessegTxtbox.Text = view.Rows[e.RowIndex].Cells["cukor"].Value.ToString();
                    alkoholNumeric.Value = (int)view.Rows[e.RowIndex].Cells["alkohol"].Value;
                    borId = (int)view.Rows[e.RowIndex].Cells["id"].Value;
                    modositBtn.Visible = true;
                    felvitelBtn.Enabled = false;
                    borGrid.Enabled = false;
                    break;
                case "Torles":
                    DialogResult res = MessageBox.Show("Törli ezt a bort?", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string result = client.Delete((int)view.Rows[e.RowIndex].Cells["id"].Value, userId);
                        MessageBox.Show(result, "Eredmény", MessageBoxButtons.OK);
                        FillGrid();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
