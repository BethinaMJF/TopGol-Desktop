//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TopGol.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Jogos
    {
        public int idJogo { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<int> idCompeticao { get; set; }
        public Nullable<int> Selecao1 { get; set; }
        public Nullable<int> Placar1 { get; set; }
        public Nullable<int> Penalt1 { get; set; }
        public Nullable<int> Selecao2 { get; set; }
        public Nullable<int> Placar2 { get; set; }
        public Nullable<int> Penalt2 { get; set; }
    
        public virtual Competicao Competicao { get; set; }
        public virtual Selecao Selecao { get; set; }
        public virtual Selecao Selecao3 { get; set; }
    }
}
