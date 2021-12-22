using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidFileManager.Logic
{
    // This interface allows you to save and load a Memory object a file
    public interface iStorage
    {
        Memory Load();
        void Save(Memory m);
    }
}
