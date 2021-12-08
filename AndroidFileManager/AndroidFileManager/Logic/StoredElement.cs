using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndroidFileManager.Logic
{
    public abstract class StoredElement
    {
        public abstract string Name { get; set; }

        public abstract string ShortName { get; }
  
        public abstract string Image { get; }

        public abstract void Copy(StoredElement e);

        public abstract Folder Paste(StoredElement e);

        public abstract Folder Move(StoredElement e);

        public abstract void  Remove(StoredElement e);

        public abstract string Type { get; }

        
    }
}
