using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PoliziaVeronica
{
    static class Polizia // accesso ai dati 
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["PoliziaVeronica"].ConnectionString;

        //mostrareAgenti
        public static List<Agente> MostraAgenti()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("Select * from Agenti", conn))
            {
                List<Agente> _agenti = new List<Agente>();

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    _agenti.Add(new Agente((int)reader["IdAgente"], reader["Nome"].ToString(), reader["Cognome"].ToString(), reader["CodiceFiscale"].ToString(), (int)reader["AnniServizio"], (DateTime)reader["DataNascita"]));

                conn.Close();

                return _agenti;
            }
        }
       


        
        public static List<Agente> AnniServizioPerAgente(int anni)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("Select * from Agenti where AnniServizio >= @anniServizio", conn))
            {
                List<Agente> _agentiPerAnniServizio = new List<Agente>();
                cmd.Parameters.AddWithValue("@anniServizio", anni);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    _agentiPerAnniServizio.Add(
                        new Agente((int)reader["IdAgente"], reader["CodiceFiscale"].ToString(), reader["Nome"].ToString(), reader["Cognome"].ToString(), (int)reader["AnniServizio"], (DateTime)reader["DataNascita"]));
                return _agentiPerAnniServizio;
            }
        }
            public static List<Agente> AgentiPerArea(int area)
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT * From Agenti inner join Competenze on Agenti.IdAgente = Competenze.IdAgente inner join AreaMetropolitana on Competenze.IdArea = AreaMetropolitana.IdArea where Competenze.IdArea = @idArea; ", conn))
                {
                    List<Agente> _agentiPerArea = new List<Agente>();
                
                    cmd.Parameters.AddWithValue("@idArea", area);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    
                        _agentiPerArea.Add(
                            new Agente((int)reader["IdAgente"], reader["CodiceFiscale"].ToString(), reader["Nome"].ToString(), reader["Cognome"].ToString(), (int)reader["AnniServizio"], (DateTime)reader["DataNascita"]));
                    return _agentiPerArea;
                }
            }
        public static void InserimentoAgente(string nome, string cognome, string codiceFiscale,DateTime dataNascita, int anniServizio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("Select * from Agenti", conn))
            {
                DataSet ds = new DataSet();

                da.Fill(ds, "Agenti");

                DataTable tabellaAgenti = ds.Tables["Agenti"];

                tabellaAgenti.Rows.Add(0,nome,cognome,codiceFiscale,dataNascita,anniServizio);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(tabellaAgenti);
               
            }
        }
    }
}
