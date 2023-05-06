using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.Model
{
    class QuizModel
    {
        public QuizModel() { }

        public List<Question> getQuestions(int index, String pathToDB)
        {
            Dictionary<int, String> QuestionsIDContent = new Dictionary<int, String>();
            List<string> AnsContent = new List<string>();
            List<int> AnsTF = new List<int>();
            List<Question> Questions = new List<Question>();




            SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + pathToDB + ";Version=3");
            connection.Open();
            SQLiteDataReader read;
            SQLiteCommand command;
            command = connection.CreateCommand();



            command.CommandText = " SELECT id_pytania, treść "+
                                    " FROM Pytania "+
                                " Where id_testu =  "+ index.ToString();
            read = command.ExecuteReader();
            while (read.Read())
            {
                QuestionsIDContent.Add((int)read["id_pytania"], (string)read["treść"]);
            }


            foreach(var que in QuestionsIDContent)
            {
                command.CommandText = " SELECT  Tresc_odp, Czy_dobra " +
                                     " FROM Odpowiedz " +
                                     " Where id_pytania =  "+que.Key.ToString();
                read = command.ExecuteReader();
                
                // Tu gzieś dekodowanie
                while (read.Read())
                {
                    AnsContent.Add((string)read["Tresc_odp"]);
                    AnsTF.Add((int)read["Czy_dobra"]);
                }

                // Tu gzieś dekodowanie 
                Questions.Add(new Question(que.Value, AnsContent.ToArray(), AnsTF.ToArray()));
                AnsContent.Clear();
                AnsTF.Clear();
            }
            connection.Close();

            return Questions;
        }
    }
}
