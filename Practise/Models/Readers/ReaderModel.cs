using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class ReaderModel
    {
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
        public string IP
        {
            get; set;
        }

        public int Port
        {
            get; set;
        }

        public ConnectionStatuses ConnectionStatus
        {
            get; set;
        }

        public string ReaderType
        {
            get; set;
        }


    }
    
}
