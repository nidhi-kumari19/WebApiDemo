//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Podetail
    {
        public string pono { get; set; }
        public string itcode { get; set; }
        public Nullable<int> qty { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Pomaster Pomaster { get; set; }
    }
}
