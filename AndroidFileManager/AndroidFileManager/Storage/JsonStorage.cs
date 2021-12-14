using AndroidFileManager.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AndroidFileManager.Storage
{
    public class JsonStorage : Logic.iStorage
    {
        private string fileName;
        public JsonStorage(string filename)
        {
            this.fileName = filename;
        }
        

        public void save(Memory m)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Memory));

            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {
                ser.WriteObject(stream, m);
            }
        }

        Memory iStorage.Load()
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


