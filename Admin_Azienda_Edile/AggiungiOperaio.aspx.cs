using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Azienda_Edile
{
    public partial class AggiungiOperaio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;

                ClearInputs(ctrl.Controls);
            }
        }
        protected void AddEmpl_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Admin_Azienda"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = "AddEmploy";
                com.Connection = conn;

                com.Parameters.AddWithValue("Nome", txtNome.Text);
                com.Parameters.AddWithValue("Cognome", txtCognome.Text);
                com.Parameters.AddWithValue("Indirizzo", txtIndirizzo.Text);
                com.Parameters.AddWithValue("CodiceFiscale", txtCF.Text);
                
                if (ckbSi.Checked) {
                    com.Parameters.AddWithValue("Coniugato", 1);
                }else {
                    com.Parameters.AddWithValue("Coniugato", 0);
                }
                
                com.Parameters.AddWithValue("FigliACarico", txtFigli.Text);
                com.Parameters.AddWithValue("Mansione", txtMansione.Text);
                com.Parameters.AddWithValue("StipendioMensile", txtStipendio.Text);

                int row = com.ExecuteNonQuery();

                if (row > 0)
                {
                    lblMessages.Visible = true;
                    lblInserito.Visible = true;
                    lblInserito.Text = "Anagrafica inserita con successo.. <a href=\"Index.aspx\"></a>";
                }
                conn.Close();

                ClearInputs(Page.Controls);


            }
            catch (Exception ex)
            {
                lblErrore.Text = ex.Message;
                lblMessages.Visible = true;
                lblErrore.Visible = true;
            }
        }
    }
}