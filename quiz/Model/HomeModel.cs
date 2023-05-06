using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Data.SQLite;



namespace quiz.Model
{
    class HomeModel
    {
        public String chooseFile() {
            String name = default;
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "DB documents (.db)|*.db";
            if (dialog.ShowDialog() == true)
                name = dialog.FileName;
            return name;
        }
        public List<String> GetQuizList(String file)
        {
            List<String> titles = new List<String>();
            try
            {
                SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + file + ";Version=3");
                connection.Open();
                SQLiteDataReader read;
                SQLiteCommand command;
                command = connection.CreateCommand();
                command.CommandText = "SELECT tytuł FROM Testy";
                read = command.ExecuteReader();
                while (read.Read())
                {
                    titles.Add((string)read["tytuł"]);
                }

                connection.Close();
                return titles;
            }
            catch(SQLiteException e)
            {
                throw new SQLiteException(
            "Nie udało się otworzyć lub odczytać bazy danych",e);
            }
        }
        public HomeModel() { }
    }
}
