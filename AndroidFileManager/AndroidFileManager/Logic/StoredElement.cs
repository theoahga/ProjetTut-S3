using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace AndroidFileManager.Logic
{
    [DataContract]
    public abstract class StoredElement
    {
        public abstract string Name { get; set; }

        public abstract string ShortName { get; }
  
        public abstract string Image { get; }

        public abstract void Copy(string sourceDirName, string destDirName, bool copySubDirs);

        public abstract void Move(string dest);

        public abstract void  Remove();

        public abstract string Type { get; }

        
    }
}
