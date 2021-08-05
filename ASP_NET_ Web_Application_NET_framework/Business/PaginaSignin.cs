using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class PaginaSignin
    {
        /* PaginaSignin    */
        public int person_id { get; set; }
       
        public String person_name { get; set; }
        public Boolean person_kind_person { get; set; }
        public Boolean person_kind_gender { get; set; }
        public int person_marital_status { get; set; }
        public DateTime person_date_birthday { get; set; }
        public String person_email_address { get; set; }
        public String person_contact_name { get; set; }
        public int person_contact_per_phone_number { get; set; }
        public DateTime person_date_insert { get; set; }
        public DateTime person_date_update { get; set; }
        public Boolean person_status { get; set; }
        public String person_key { get; set; }
        public String person_password { get; set; }
        public String person_email { get; set; }
        public String person_password_confirm { get; set; }

        public String msgErro { get; set; }

        public List<PaginaSignin> Lista()
        {
            var listaSignin = new List<PaginaSignin>();

            var signinDb = new Database.DatabaseSignin();

            foreach (DataRow row in signinDb.Lista().Rows) // System.Data
            {
                var signin = new PaginaSignin();
                signin.person_id = Convert.ToInt32(row["person_id"]);
                signin.person_email = row["person_email_address"].ToString();
                signin.person_name = row["person_name"].ToString();
                signin.person_key = row["person_key"].ToString();
                signin.person_password = row["person_password"].ToString();
                signin.person_status = Convert.ToBoolean(row["person_status"]);
                /* signin.person_date_update = Convert.ToDateTime(row["person_dateupdate"]); */

                listaSignin.Add(signin);

            }

            return listaSignin;
        }

        public void Save()
        {
            new Database.DatabaseSignin().Salvar(this.person_id,
                                                        this.person_name,
                                                        this.person_kind_person,
                                                        this.person_kind_gender,
                                                        this.person_marital_status,
                                                        this.person_date_birthday,
                                                        this.person_email_address,
                                                        this.person_contact_name,
                                                        this.person_contact_per_phone_number,
                                                        this.person_date_insert,
                                                        this.person_date_update,
                                                        this.person_status,
                                                        this.person_key,
                                                        this.person_password);

        }

        /*=====================================================================================================*/
        /* Esta rotina verifica se existe o email informado para recuração de password existe no SGDB Persons  */
        /*=====================================================================================================*/


        /* 
        public void SaveRecupera() 
         */
        public bool SaveRecupera(bool recuperaOk, string person_email_address)
        {
            var listaSignin = new PaginaSignin();
            listaSignin = BuscaPorEmail(person_email_address);
            var id = listaSignin.person_id;
            var email = listaSignin.person_email_address;

            if (email != null)
            {

                // new Database.DatabaseSignin().SalvaRecupera(this.person_id, this.person_email);

                new Database.DatabaseSignin().SalvaRecupera(id, email);

                recuperaOk = true;
            }
            else
            {
                recuperaOk = false;
            }
            return recuperaOk;
        }


        /*=====================================================================================================*/
        /* A inclusão de novo usuário não deve permitir que o email e a chave de acesso sejam duplicados.      */
        /* Esta rotina verifica se existe o emaile a chave de acesso informados na inclusão de um novo         */
        /* usuário já exitem no SGDB Persons.                                                                  */
        /*=====================================================================================================*/

        public string ValidaChave_e_Email(string person_email_address, string person_key)
        {
            var listaSignin = new PaginaSignin();
            String msgErro = "";

            /* BuscaPorEmail  */

            listaSignin = BuscaPorEmail(person_email_address);
            
            if (listaSignin.person_email_address != null)
            {
                msgErro = "The email informed already exists.";
                return msgErro;
            }

            /* BuscaPorKey  */

            listaSignin = BuscaPorKey(person_key);

            if (listaSignin.person_key != null)
            {
                msgErro = "The User Key informed already exists.";
                return msgErro;
            }

            return msgErro;
        }



        public PaginaSignin BuscaPorEmail(string person_email_address)
        {
            var listaSignin = new PaginaSignin();

            var signinDb = new Database.DatabaseSignin();
            var signin = new PaginaSignin();
            foreach (DataRow row in signinDb.BuscaPorEmail(person_email_address).Rows)
            {

                signin.person_id = Convert.ToInt32(row["person_id"]);
                signin.person_name = row["person_name"].ToString();
                signin.person_email_address = row["person_email_address"].ToString();
                signin.person_key = row["person_key"].ToString();
                signin.person_password = row["person_password"].ToString();
                signin.person_status = Convert.ToBoolean(row["person_status"]);
                /* signin.person_date_update = Convert.ToDateTime(row["person_dateupdate"]); */
            }

            // return listaSignin;
            return signin;
        }

        public PaginaSignin BuscaPorKey(string person_key)
        {
            var listaSignin = new PaginaSignin();

            var signinDb = new Database.DatabaseSignin();
            var signin = new PaginaSignin();
            foreach (DataRow row in signinDb.BuscaPorKey(person_key).Rows)
            {

                signin.person_key = row["person_key"].ToString();

            }

            // return listaSignin;
            return signin;
        }
    }
}
