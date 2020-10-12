using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace GSB_WPF
{
    public class CURS
    {
        Boolean isEnded;

        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;

        public static string connectionString = "server = localhost; user id = root; database = gsb_db";
        public CURS(string connec)
        {
            connection = new MySqlConnection(connec);
            connection.Open();
            reader = null;     
        }
        public MySqlConnection getmyConnection()
        {
            return connection;
        }
        public void ReqSelect(string req)
        {
            command = new MySqlCommand(req, connection);
            reader = command.ExecuteReader();
            isEnded = false;
            suivant();
        }
        public void Close()
        {
            if ( reader!= null) 
                reader.Close();
            connection.Close();
        }
        public void suivant()
        {
            Boolean flag;

            if (!isEnded)
            {
                flag = reader.Read();
                if (flag == true)
                    isEnded = false;
                else
                    isEnded = true;
            }
        }
        public void ReqAdmin(string req)
        {  
            command = new MySqlCommand(req, connection);
            command.ExecuteNonQuery();
        }
        public object Field(string nomChamp)
        {
            // if (!fin)
            return reader[nomChamp];
            //  else
            // return null;
        }
        public Boolean End()
        {
            return isEnded;
        }
        public string Count(string req)
        {
            command = new MySqlCommand(req, connection);
            return command.ExecuteScalar().ToString();
        }
    }
}
