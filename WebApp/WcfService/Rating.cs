//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rating
    {
        public int IdRating { get; set; }
        public int IdUser { get; set; }
        public int IdAlbum { get; set; }
        public Nullable<int> Rating1 { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual User User { get; set; }
    }
}
