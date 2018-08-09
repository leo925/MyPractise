using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practise.Db
{
    public class MyPractiseDb : DbContext
    {
        public MyPractiseDb():base("name=PractiseConStr")
        {
        }
        public DbSet<ReaderModel> Readers
        {
            get;
            set;
        }

       public DbSet<ReaderDetails> ReaderDetails
        {
            get;set;
        }

        public DbSet<ReaderReviewModel> ReaderReviews
        {
            get;set;
        }
    }



}