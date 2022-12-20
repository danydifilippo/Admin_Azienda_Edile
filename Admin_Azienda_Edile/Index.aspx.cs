using Admin_Azienda_Edile;
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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Admin_Azienda"].ToString();
                    conn.Open();

                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT * FROM Dipendente";
                    com.Connection = conn;

                    SqlDataReader reader = com.ExecuteReader();

                    List<Gestione> listDip = new List<Gestione>();

                    while (reader.Read())
                    {
                        Gestione d = new Gestione();
                        d.IdDipendente = Convert.ToInt32(reader["IdDipendente"]);
                        d.Nome = reader["Nome"].ToString();
                        d.Cognome = reader["Cognome"].ToString();
                        d.Mansione = reader["Mansione"].ToString();
                        d.StipendioMensile = Convert.ToDouble(reader["StipendioMensile"]);


                        listDip.Add(d);
                    }

                    GWDipendenti.DataSource = listDip;
                    GWDipendenti.DataBind();
                    
                    conn.Close();



                   
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
}