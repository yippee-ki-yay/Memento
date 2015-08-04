using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


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


        /// <summary>
        /// Allows user to choose what file with questions/answers he wants to choose
        /// </summary>
        /// <returns>returns if questions are opened and walid, or not</returns>
        public string openQuestions(){

            System.Windows.Forms.OpenFileDialog choofdlog = new System.Windows.Forms.OpenFileDialog();
            choofdlog.Title = "Izaberite fajl s pitanjima";
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                return sFileName;
            }
            else return "";
        }



        public bool loadFile(string filePath)
        {

            string text = System.IO.File.ReadAllText(openQuestions(), Encoding.UTF8);

            string[] parts = Regex.Split(text, @"\b\d+\.");
                  

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
