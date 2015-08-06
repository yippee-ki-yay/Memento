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
            
            int counter = 0;
            string line;
            string[] quiestions = new string[1000];
            string[] answers = new string[1000];
            int cnt_q = 0;
            int cnt_a = 0;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {

                if (counter % 2 == 0)
                {
                    quiestions[cnt_q] = line;
                    cnt_q++;

                }
                else {
                    answers[cnt_a] = line;
                    cnt_a++;
                }
                counter++;

            }

            file.Close();
            
            
            
            for(int i = 0; i < answers.Length; i++){
                qaList.Add(new Tuple<string,string>(quiestions[i],answers[i]));

            }

         
            
            return false;
        }


        public Tuple<string, string> getRandom()
        {
            Random rnd = new Random();
            return qaList[rnd.Next(qaList.Count)];
        }
    }
}
