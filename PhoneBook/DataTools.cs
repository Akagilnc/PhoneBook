using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class DataTools
    {
        private SQLiteConnection sqLiteConnection;
        public DataTools()
        {
            sqLiteConnection = GetConnection();
        }

        public DataTable Query(string sqlCommand, String parameter)
        {
            SQLiteDataAdapter ad;
            var dt = new DataTable();

            try
            {
                sqLiteConnection.Open();
                var sqLiteCommand = sqLiteConnection.CreateCommand();
                sqLiteCommand.CommandText = sqlCommand;
                sqLiteCommand.CommandTimeout = 15;
                sqLiteCommand.CommandType = CommandType.Text;
                sqLiteCommand.Parameters.Add(new SQLiteParameter("@name", '%' + parameter + '%'));
                ad = new SQLiteDataAdapter(sqLiteCommand);
                ad.Fill(dt);
            }
            catch (SQLiteException)
            {
                throw;
            }
            finally
            {
                sqLiteConnection.Close();
            }
            return dt;
        }

        public int NonQuery(string[] sqlCommands)
        {

            sqLiteConnection.Open();
            var transaction = sqLiteConnection.BeginTransaction();

            var count = 0;
            try
            {
                var sqLiteCommand = sqLiteConnection.CreateCommand();
                sqLiteCommand.Transaction = transaction;
                sqLiteCommand.CommandTimeout = 15;
                sqLiteCommand.CommandType = CommandType.Text;
                foreach (var sql in sqlCommands)
                {
                    sqLiteCommand.CommandText = sql;
                    count += sqLiteCommand.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (SQLiteException)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                sqLiteConnection.Close();
            }
            return count;
        }

        private SQLiteConnection GetConnection()
        {
            var path = Directory.GetCurrentDirectory();

            return
                new SQLiteConnection(
                    @"Data Source = ..\..\..\PhoneBook.db");
        }
    }
}
