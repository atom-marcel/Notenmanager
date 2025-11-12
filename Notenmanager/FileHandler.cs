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
            string jsonData = ConvertDataToString();
            File.WriteAllText(filePath, jsonData);
        }

        public NotenmanagerData? Load()
        {
            StreamReader jsonData = File.OpenText(filePath);

            NotenmanagerData? data = JsonSerializer.Deserialize<NotenmanagerData>(jsonData.BaseStream);

            jsonData.Close();

            if(data == null)
            {
                MessageBox.Query("Info", "Konnte die Datei nicht richtig einlesen. Versuchen Sie eine .json Datei, die mit dem Notenmanager erstellt wurde, zu laden!");
            }

            return data;
        }
    }
}
