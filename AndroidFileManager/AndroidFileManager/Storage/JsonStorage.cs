using AndroidFileManager.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AndroidFileManager.Storage
{
    // This class extends from the interface IStorage
    public class JsonStorage : Logic.iStorage
    {
        //Attribute
        private string fileName;

        // The JsonStorage class constructor
        public JsonStorage(string filename)
        {
            this.fileName = filename;
        }
        
        // This function allows to save a Memory object in the data file 
        public void Save(Memory m)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Memory));

            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {
                ser.WriteObject(stream, m);
            }
        }

        // This function allows to load a Memory object from the data file 
        public Memory Load()
        {
            Memory memory = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Memory));
                using (Stream stream = new FileStream(fileName, FileMode.Open))
                {
                    memory = ser.ReadObject(stream) as Memory;
                }
            }
            catch
            {
                memory = new Memory();
            }

            return memory;
        }
    }
}


