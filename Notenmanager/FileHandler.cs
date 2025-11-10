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
    public partial class FileHandler
    {
        private string filePath;
        private JsonDocument document;
        private Dictionary<string, object> data;
        public FileHandler(string filePath) 
        {
            this.filePath = filePath;
        }

        public void SetData(Dictionary<string, object> d)
        {
            this.data = d;
        }
        public bool ConvertDocument()
        {
            // TODO Methode implementieren
            //document = new JsonDocument();
            return false;
        }

        public void Save()
        {
            // TODO Methode implementieren
        }

        public void Load()
        {
            // TODO Methode implementieren
        }
    }
}
