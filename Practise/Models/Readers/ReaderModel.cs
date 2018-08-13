using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public virtual ICollection<ReaderReviewModel> Reviews
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

        [Range(1,10)]
        public int Rating
        {
            get; set;
        }
        [StringLength(1024)]
        [Display(Name ="revew content")]
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
