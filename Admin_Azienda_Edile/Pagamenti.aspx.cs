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
    public partial class Pagamenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Admin_Azienda"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.CommandText = "SELECT * FROM Dipendente AS D FULL JOIN PAGAMENTI AS P ON D.IdDipendente = P.IdDipendente INNER JOIN STIPENDIO AS S on S.IdStipendio = P.IdStipendio ORDER BY P.DataPagamento desc";
                com.Connection = conn;


                SqlDataReader read = com.ExecuteReader();

                List<Gestione> listdip = new List<Gestione>();

                while (read.Read())
                {
                    Gestione dip = new Gestione();
                    dip.Nome = read["Nome"].ToString();
                    dip.Nome = read["Cognome"].ToString();
                    dip.TipoStipendio = read["TipoStipendio"].ToString();
                    dip.DataPag = Convert.ToDateTime(read["DataPagamento"]);
                    dip.ImportoPag = Convert.ToDouble(read["ImportoPagamento"]);
                    listdip.Add(dip);
                }

                GWPagamenti.DataSource = listdip;
                GWPagamenti.DataBind();

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