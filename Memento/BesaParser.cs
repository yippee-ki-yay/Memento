using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class BesaParser
    {
        List<Tuple<string, string>> qaList { get; set; }
        public BesaParser() {
            qaList = new List<Tuple<string, string>>();

        }

        public bool parseFile()
        {
            //contains method for opening files with
            QuestionManager qm = new QuestionManager();
            string path = qm.openQuestions();

            if (path.Equals(""))
                return false;

            string question, answer;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(path);

            while ((question = file.ReadLine()) != null)
            {
                if ((answer = file.ReadLine()) != null)
                {
                    qaList.Add(new Tuple<string, string>(question, answer));
                }
            }

            file.Close();

            return true;
        }

   

        public Tuple<string, string> getRandom()
        {
            Random rnd = new Random();
            return qaList[rnd.Next(qaList.Count)];
        }
    }
}
