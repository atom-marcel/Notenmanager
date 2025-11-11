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
            Data = new NotenmanagerData(filePath);
        }
        public string ConvertDataToString()
        {
            return Data.Serialize();
        }

        public void Save()
        {
            string jsonData = ConvertDataToString();
            File.WriteAllText(filePath, jsonData);
        }

        public bool Load()
        {
            string jsonData = File.ReadAllText(filePath);

            bool couldLoad = Data.Deserialize(jsonData);

            if(!couldLoad)
            {
                MessageBox.Query("Info", "Konnte die Datei nicht richtig einlesen. Versuchen Sie eine .json Datei, die mit dem Notenmanager erstellt wurde, zu laden!");
            }

            return couldLoad;
        }
    }
}
