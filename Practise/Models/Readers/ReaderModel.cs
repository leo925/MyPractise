using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public ICollection<ReaderReviewModel> Reviews
        {
            get; set;
        }
    }


    public class ReaderDetails
    {
        public int Id
        {
            get; set;
        }

        public int Owner
        {
            get; set;
        }

        public string Des
        {
            get; set;
        }

        public int ReaderId
        {
            get; set;
        }
        
        
    }

    public class ReaderReviewModel
    {
        public int Id
        {
            get; set;
        }

        public decimal Rating
        {
            get; set;
        }

        public string Content
        {
            get; set;
        }

        [ForeignKey("Reader")]
        public int ReaderId
        {
            get; set;
        }

        public ReaderModel Reader
        {
            get; set;
        }
    }

}
