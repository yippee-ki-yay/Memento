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

        //TODO : Ne treba da se pali kao prva opcija vec kao dodatna


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
        /// Ucitava fajl i prosledjuje odredjenoj funkciji za parsiranje tako da moze da se prosiri sa bilo kojojm
        /// </summary>
        /// <returns>Vraca da li je sve uspesno proslo</returns>
        public bool loadFile(int tipParsiranja)
        {
            string filePath = openQuestions();

            if (filePath.Equals(""))
                return false;

            string text = System.IO.File.ReadAllText(filePath, Encoding.ASCII);

            if (tipParsiranja == 1)
                return parseOriginal(text);
            else if (tipParsiranja == 2)
                return parseStandard(text);

            return false;
        }

        /// <summary>
        /// Pisi ovde tvoju funkciju da isparsira onaj format sto si napravio
        /// </summary>
        public bool parseStandard(string text)
        {
            return false;
        }

        /// <summary>
        /// Parsira fajl dok je u originalnoj formi polu struktiruan
        /// NUMBER. pitanje ? odogovor
        /// </summary>
        public bool parseOriginal(string text)
        {
            string[] parts = Regex.Split(text, @"\b\d+\.");

            //string[] parts = results.Split('?');

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
    }
}
