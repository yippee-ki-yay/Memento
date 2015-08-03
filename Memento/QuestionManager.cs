using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Memento
{
    class QuestionManager
    {
        List<Tuple<string, string>> qaList { get; set; }
        private Random rnd = new Random();
 
        public QuestionManager()
        {
            qaList = new List<Tuple<string, string>>();
        }

        public bool loadFile(string filePath)
        {
            string text = System.IO.File.ReadAllText("sims_teorija.txt", Encoding.UTF8);

            string[] parts = Regex.Split(text, @"\d.");
                  

            //string[] parts = results.Split('?');

            for (int i = 1; i < parts.Length; ++i )
            {
                string[] t = parts[i].Split('?');

                if(t.Length == 2)
                    qaList.Add(new Tuple<string, string>(t[0], t[1]));
            }

            return true;
        }

        public Tuple<string, string> getRandom()
        {
            return qaList[rnd.Next(qaList.Count)];
        }
    }
}
