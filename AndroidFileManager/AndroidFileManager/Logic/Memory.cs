using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AndroidFileManager.Logic
{
    [DataContract]
    public class Memory
    {
        [DataMember]private StoredElement copyElementPath;
        [DataMember]private StoredElement moveElementPath;


        public Memory()
        {
            this.copyElementPath = null;
            this.moveElementPath = null;
        }

        public StoredElement CopyElementPath
        {
            get { return this.copyElementPath; }
            set
            {
                this.copyElementPath = value;
            }
        }

        public StoredElement MoveElementPath
        {
            get { return this.moveElementPath; }
            set
            {
                this.moveElementPath = value;
            }
        }
    }
}
