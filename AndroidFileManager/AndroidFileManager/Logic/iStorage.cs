﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidFileManager.Logic
{
    public interface iStorage
    {
        Memory Load();
        void save(Memory m);
    }
}
