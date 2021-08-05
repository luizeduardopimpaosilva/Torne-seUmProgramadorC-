using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class DatabaseSignin
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn())) // System.Data.SqlClient
            {
                string queryString = "select * from Persons";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable BuscaPorEmail(string person_email_address)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Persons where person_email_address = '" + person_email_address + "' ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }



        public DataTable BuscaPorKey(string person_key)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Persons where person_key = '" + person_key + "' ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }


        // public void Salvar(int person_id, string person_name, string person_email, string person_key, string person_password, string person_password_confirm, DateTime person_date_update, DateTime person_date_insert)
        public void Salvar  (int person_id,
                            string person_name,
                            Boolean person_kind_person,
                            Boolean person_kind_gender,
                            int person_marital_status,
                            DateTime person_date_birthday,
                            string person_email_address,
                            string person_contact_name,
                            int person_contact_per_phone_number,
                            DateTime person_date_insert,
                            DateTime person_date_update,
                            Boolean person_status,
                            string person_key,
                            string person_password)

        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                var queryString = "";
                person_status = true;
                person_kind_person = false;
                person_marital_status = 0;
                person_date_insert = DateTime.Now;
                person_date_update = DateTime.Now;
                person_date_birthday = DateTime.Now;
                if (person_id != 0)
                {
                    queryString = "update Persons set person_password='" + person_password + "', person_date_update='" + person_date_update.ToString("yyyy-MM-dd HH:mm:sss") + "' where person_id=" + person_id;
                }
                else
                {
                    
                    queryString = "insert into Persons (" + "person_name, person_kind_person, person_kind_gender, person_marital_status, person_date_birthday, person_email_address, person_contact_name, person_contact_per_phone_number, person_date_insert, person_date_update, person_status, person_key, person_password) values('" 
                                                                    + person_name + "','"
                                                                    + person_kind_person + "','"
                                                                    + person_kind_gender + "','"
                                                                    + person_marital_status + "','"
                                                                    + person_date_birthday + "','"
                                                                    + person_email_address + "','"
                                                                    + person_contact_name + "','"
                                                                    + person_contact_per_phone_number + "','"
                                                                    + person_date_insert + "','"
                                                                    + person_date_update + "','"
                                                                    + person_status +"','"
                                                                    + person_key +"','"
                                                                    + person_password + "')";

                    // queryString = "insert into Persons(person_key, person_password, person_name, person_kind_person, person_marital_status, person_email_address, person_status) values('" + person_key + "','" + person_password + "','" + "','" + person_name + "','" + "','" + person_kind_person + "','" + person_marital_status + "','" + "','" + person_email + "','" + person_status + "')";
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void SalvaRecupera(int person_id, string person_email)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                var queryString = "";
                var person_password = "Reset";

                DateTime person_date_update = DateTime.Now;
                if (person_id != 0)
                {
                    queryString = "update Persons set person_password='" + person_password + "' where person_id=" + person_id;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
