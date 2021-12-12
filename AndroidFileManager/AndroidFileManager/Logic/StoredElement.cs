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

        public abstract void Copy();

        public abstract Folder Paste();

        public abstract Folder Move(StoredElement e);

        public abstract void  Remove();

        public abstract string Type { get; }

        
    }
}
