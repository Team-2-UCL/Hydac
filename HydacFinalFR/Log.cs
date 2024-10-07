using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HydacFinalFR
{

    public class Log
    {
        private string dato = DateTime.Now.ToString("dd.MM.yyyy");
        private string loggen;

        public void Gemtillog(string logbesked)
        {

            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + logbesked + Environment.NewLine);
        }
        public void Tjeklogfindes()
		{
            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            bool exists = fileInfo.Exists;
            if (exists == false)
                using (FileStream fs = File.Create(fileName)) ;
        }
        public string Hentloggen()
        {
            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                if (fs.Read(b, 0, b.Length) > 0)
                {
                    loggen = "Loggen for dato: " + dato + "\n\n" + temp.GetString(b) + "\n\nTryk enter for at gå tilbage.";
                    return loggen;
                }
                else
                {
                    loggen = "Loggen for dato: " + dato + "\n\nLOGGEN ER TOM.\n\nTryk enter for at gå tilbage.";
                    return loggen;
                }
            }
        }
	}
}

