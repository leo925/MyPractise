//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFPractise
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReaderReviewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public int ReaderId { get; set; }
    
        public virtual ReaderModels ReaderModel { get; set; }
    }
}
