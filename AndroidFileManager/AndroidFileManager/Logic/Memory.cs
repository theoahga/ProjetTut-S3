using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AndroidFileManager.Logic
{
    // The Memory object allows you to keep in memory the element to copy or move
    [DataContract]
    public class Memory
    {
        // Attributes
        [DataMember]private string copyElementPath;
        [DataMember]private string moveElementPath;

        // This Memory class constructor
        public Memory()
        {
            this.copyElementPath = null;
            this.moveElementPath = null;
        }

        // The copyElementPath property
        public string CopyElementPath
        {
            get { return this.copyElementPath; }
            set
            {
                this.copyElementPath = value;
            }
        }

        // The moveElementPath property
        public string MoveElementPath
        {
            get { return this.moveElementPath; }
            set
            {
                this.moveElementPath = value;
            }
        }
    }
}
