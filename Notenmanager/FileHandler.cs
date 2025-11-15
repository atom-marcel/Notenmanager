using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Notenmanager
{
    internal class FileHandler
    {
        private string filePath;
        public NotenmanagerData Data;
        public FileHandler(string filePath) 
        {
            this.filePath = filePath;
            Data = new NotenmanagerData();
        }
        public string ConvertDataToString()
        {
            return JsonSerializer.Serialize(Data, new JsonSerializerOptions() { WriteIndented = true });
        }

        public void Save()
        {
            Data.changeDate = DateTime.Now;
            Data.name = Path.GetFileNameWithoutExtension(filePath);
            string jsonData = ConvertDataToString();
            File.WriteAllText(filePath, jsonData);
        }

        public NotenmanagerData? Load()
        {
            string jsonData = File.ReadAllText(filePath);
            NotenmanagerData? data = null;
            try
            {
                data = JsonSerializer.Deserialize<NotenmanagerData>(jsonData);

                if(data.subjects == null || 
                    data.learningFields == null || 
                    data.exams == null || 
                    data.changeDate == DateTime.MinValue)
                {
                    data = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.ErrorQuery("Warning", e.Message);
            }

            if(data == null)
            {
                MessageBox.Query("Info", "Konnte die Datei nicht richtig einlesen. Versuchen Sie eine .json Datei, die mit dem Notenmanager erstellt wurde, zu laden!");
            }

            return data;
        }
    }
}
