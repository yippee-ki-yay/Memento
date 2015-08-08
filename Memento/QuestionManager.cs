using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Memento
{
    public class QuestionManager
    {
        private List<Tuple<string, string>> qaList { get; set; }
        private Random rnd = new Random();
        private int currIndex = 0;
 
        public QuestionManager()
        {
            qaList = new List<Tuple<string, string>>();
        }

        /// <summary>
        /// Allows user to choose what file with questions/answers he wants to choose
        /// </summary>
        /// <returns>returns if questions are opened and valid, or not</returns>
        public string openQuestions(){

            OpenFileDialog choofdlog = new OpenFileDialog();
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

        /// <summary>
        /// Reads and parses the file with a standard format for this app
        /// where the Q/A pair is separated by enter
        /// </summary>
        public bool parseStandard(string filePath)
        {
            if (filePath == "")
                return false;

            string question, answer;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(filePath);

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

        /// <summary>
        /// It reads and parses the file 
        /// Format: NUMBER. pitanje ? odogovor
        /// </summary>
        public bool parseOriginal(string filePath)
        {
            if (filePath == "")
                return false;

            string text = System.IO.File.ReadAllText(filePath, Encoding.ASCII);

            //split each QA pair at the beginig every question starts with "Number."
            string[] parts = Regex.Split(text, @"\b\d+\.");

            //we split the pair Q/A (every question ends with ? )
            for (int i = 1; i < parts.Length; ++i)
            {
                string[] t = parts[i].Split('?');

                if (t.Length == 2)
                    qaList.Add(new Tuple<string, string>(t[0], t[1]));
            
            }

            return true;
        }

        /// <summary>
        /// Vraca nasumicno pitanje/odogvor iz liste pitanje odgovora
        /// </summary>
        /// <returns></returns>
        public Tuple<string, string> getRandom()
        {
            return qaList[rnd.Next(qaList.Count)];
        }

        public Tuple<string, string> getSequentail()
        {
            if (currIndex == qaList.Count)
                currIndex = 0;

            return qaList[currIndex++];
        }
    }
}
