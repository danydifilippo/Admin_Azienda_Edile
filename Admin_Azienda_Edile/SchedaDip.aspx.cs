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
    public partial class SchedaDip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["IdDipendente"];

            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Admin_Azienda"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.Parameters.AddWithValue("Id", id);
                com.CommandText = "SELECT * FROM Dipendente AS D FULL JOIN PAGAMENTI AS P ON D.IdDipendente = P.IdDipendente INNER JOIN STIPENDIO AS S on S.IdStipendio = P.IdStipendio where D.IdDipendente=@Id";
                com.Connection = conn;


                SqlDataReader read = com.ExecuteReader();

                List<Gestione> listdip = new List<Gestione>();

                while (read.Read())
                {
                    Gestione dip = new Gestione();
                    dip.TipoStipendio = read["TipoStipendio"].ToString();
                    dip.DataPag = Convert.ToDateTime(read["DataPagamento"]);
                    dip.ImportoPag = Convert.ToDouble(read["ImportoPagamento"]);
                    listdip.Add(dip);
                }

                GridViewPag.DataSource = listdip;
                GridViewPag.DataBind();

                conn.Close();

            }
            catch (Exception ex)
            {
                lblErrore.Text = ex.Message;
                lblMessages.Visible = true;
                lblErrore.Visible = true;
            }

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Admin_Azienda"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.CommandText = "SELECT * FROM Dipendente WHERE IdDipendente=@IdDipendente";
                com.Connection = conn;

                com.Parameters.AddWithValue("IdDipendente", id);

                SqlDataReader r = com.ExecuteReader();

                Gestione d = new Gestione();

                while (r.Read())
                {
                    d.IdDipendente = Convert.ToInt32(r["IdDipendente"]);
                    d.Nome = r["Nome"].ToString();
                    d.Cognome = r["Cognome"].ToString();
                    d.Coniugato = Convert.ToBoolean(r["Coniugato"].ToString());
                    d.Indirizzo = r["Indirizzo"].ToString();
                    d.Cod_Fisc = r["CodiceFiscale"].ToString();
                    d.Figli = Convert.ToInt32(r["FigliACarico"]);
                    d.Mansione = r["Mansione"].ToString();
                    d.StipendioMensile = Convert.ToDouble(r["StipendioMensile"]);
                }

                lblId.Text = d.IdDipendente.ToString();
                lblCognome.Text = d.Cognome.ToString();
                lblNome.Text = d.Nome.ToString();
                lblMansione.Text = d.Mansione.ToString();
                lblIndirizzo.Text = d.Indirizzo.ToString();
                lblCF.Text = d.Cod_Fisc.ToString();
                lblStipendio.Text = d.StipendioMensile.ToString("c2");
                if (d.Coniugato)
                {
                    lblConiugato.Text = "Coniugato";
                }
                else
                {
                    lblConiugato.Text = "Non Coniugato";
                }
                if (d.Figli > 0)
                {
                    lblFigli.Text = $"{d.Figli} figli a carico";
                }
                else
                {
                    lblFigli.Text = "Nessun figlio a carico";
                }
                lblDip.Text = $"{d.Nome} {d.Cognome}";

                conn.Close();

            }
            catch (Exception ex)
            {
                lblErrore.Text = ex.Message;
                lblMessages.Visible = true;
                lblErrore.Visible = true;
            }

            if (!IsPostBack)
            {

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["Admin_Azienda"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM STIPENDIO";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Gestione s = new Gestione();
                    s.IdStipendio = Convert.ToInt32(reader["IdStipendio"]);
                    s.TipoStipendio = reader["TipoStipendio"].ToString();
                    ListItem l = new ListItem(s.TipoStipendio, s.IdStipendio.ToString());
                    ddlTipoStip.Items.Add(l);
                }



                connection.Close();

            }

        }


        protected void AddPay_Click(object sender, EventArgs e)
        {
            Payment.Visible = true;
        }


        protected void SavePay_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["IdDipendente"];
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Admin_Azienda"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = "AddPayment";
                com.Connection = conn;

                com.Parameters.AddWithValue("IdDipendente", id);
                com.Parameters.AddWithValue("IdStipendio", ddlTipoStip.SelectedItem.Value);
                com.Parameters.AddWithValue("DataPagamento", Calendar1.SelectedDate);
                com.Parameters.AddWithValue("ImportoPagamento", txtImporto.Text);

                int row = com.ExecuteNonQuery();

                if(row>0)
                {
                    Payment.Visible = false;
                    lblMessages.Visible = true;
                    lblPayInsert.Visible = true;
                    lblPayInsert.Text = "Pagamento inserito con successo!";
                }

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
