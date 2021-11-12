using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Laura_Gagliani
{
    class DbManager : IManager<Agente>
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Add(Agente item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Agente values (@nome, @cognome, @cf, @area, @annoInizio)";
                command.Parameters.AddWithValue("@nome", item.Nome);
                command.Parameters.AddWithValue("@cognome", item.Cognome);
                command.Parameters.AddWithValue("@cf", item.CodiceFiscale);
                command.Parameters.AddWithValue("@area", item.AreaGeografica);
                command.Parameters.AddWithValue("@annoInizio", item.AnnoInizio);

                int rows = command.ExecuteNonQuery();
                connection.Close();

                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }

        }

        public bool CheckDuplicates(Agente item)
        {
            List<Agente> agenti = GetAll();
            foreach (Agente a in agenti)
            {
                if (item.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Agente> GetAll()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Agente";

                SqlDataReader reader = command.ExecuteReader();
                List<Agente> listaAgenti = new List<Agente>();

                while (reader.Read())
                {
                    Agente a = new Agente();

                    a.Nome = (string)reader["Nome"];
                    a.Cognome = (string)reader["Cognome"];
                    a.CodiceFiscale = (string)reader["CodiceFiscale"];
                    a.AreaGeografica = (string)reader["AreaGeografica"];
                    a.AnnoInizio = (int)reader["AnnoInizio"];

                    listaAgenti.Add(a);
                }

                connection.Close();
                return listaAgenti;
            }
        }

        public List<Agente> GetByAnniServizioMinimi(int anniMin)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "select * from Agente where AnnoInizio<=@annoRichiesto";
                command.Parameters.AddWithValue("@annoRichiesto", (DateTime.Today.Year - anniMin));

                SqlDataReader reader = command.ExecuteReader();
                List<Agente> listaAgenti = new List<Agente>();

                while (reader.Read())
                {
                    Agente a = new Agente();

                    a.Nome = (string)reader["Nome"];
                    a.Cognome = (string)reader["Cognome"];
                    a.CodiceFiscale = (string)reader["CodiceFiscale"];
                    a.AreaGeografica = (string)reader["AreaGeografica"];
                    a.AnnoInizio = (int)reader["AnnoInizio"];

                    listaAgenti.Add(a);
                }

                connection.Close();
                return listaAgenti;
            }
        }

        public List<Agente> GetByAreaGeografica(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "select * from Agente where AreaGeografica=@areaRichiesta";
                command.Parameters.AddWithValue("@areaRichiesta", area);

                SqlDataReader reader = command.ExecuteReader();
                List<Agente> listaAgenti = new List<Agente>();

                while (reader.Read())
                {
                    Agente a = new Agente();

                    a.Nome = (string)reader["Nome"];
                    a.Cognome = (string)reader["Cognome"];
                    a.CodiceFiscale = (string)reader["CodiceFiscale"];
                    a.AreaGeografica = (string)reader["AreaGeografica"];
                    a.AnnoInizio = (int)reader["AnnoInizio"];

                    listaAgenti.Add(a);
                }

                connection.Close();
                return listaAgenti;
            }
        }


    }
}
