using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AndroidFileManager.Logic
{
    [DataContract]
    public class Memory
    {
        [DataMember]private string copyElementPath;
        [DataMember]private string moveElementPath;


        public Memory()
        {
            this.copyElementPath = null;
            this.moveElementPath = null;
        }

        public string CopyElementPath
        {
            get { return this.copyElementPath; }
            set
            {
                this.copyElementPath = value;
            }
        }

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
