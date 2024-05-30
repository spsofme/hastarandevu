using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HastaRandevuKayit.DataAccess.Utils
{
    public class DBUtil
    {
        static string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Users\kerim\Documents\okul\GörselProgramlama\HastaRandevuKayit\HastaRandevuDB.accdb;Persist Security Info=False;";
        public static OleDbConnection connection = new(ConnectionString);

        public static bool DatabaseQuery(Action action)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                action();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public static bool DatabaseQuery(string query)
        {
            try
            {
                connection.Open();
                var command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }

        public static OleDbDataReader DatabaseQueryReader(string query)
        {
            try
            {
                connection.Open();
                var command = new OleDbCommand(query, connection);
                var reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
        }
    }
}
