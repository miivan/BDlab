using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BDLab
{
    class Functions
    {
        public static void openFile(string fileName, DataGridView dg)
        {
            using (StreamReader sr = new StreamReader(fileName, false))
            {
                string[] line = sr.ReadToEnd().Split('\r');
                for (int i = 0; i < Convert.ToInt32(line.Count() - 1); i++)
                {
                    string[] row = { line[i].Split('|')[0], line[i].Split('|')[1], line[i].Split('|')[2], line[i].Split('|')[3], line[i].Split('|')[4] };
                    dg.Rows.Add(row);
                }
                sr.Close();
            }
        }
        
        public static void saveDGV(string fileName, DataGridView dg)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                for (int i = 0; i < Convert.ToInt32(dg.Rows.Count - 1); i++)
                {
                    string line = "";
                    for (int j = 0; j < Convert.ToInt32(dg.Rows[i].Cells.Count); j++)
                        line += dg.Rows[i].Cells[j].Value.ToString() + "|";
                    sw.WriteLine(line);
                }
                sw.Close();
            }
        }

        private void sortFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, false))
            {
                string[] line = sr.ReadToEnd().Split('\r');
                sr.Close();
                for (int l = 0; l < line.Count() - 1; l++)
                {
                    for (int j = 0; j < line.Count() - l - 2; j++)
                    {
                        if (int.Parse(line[j].Split('|')[0]) > int.Parse(line[j + 1].Split('|')[0]))
                        {
                            string temp = line[j];
                            line[j] = line[j + 1];
                            line[j + 1] = temp;
                            //crutch++;
                        }
                    }
                }
                StreamWriter sw = new StreamWriter(fileName, false);
                foreach (string str in line)
                    sw.WriteLine(str);
                sw.Close();
            }
        }

    }
}
