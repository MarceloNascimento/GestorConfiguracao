//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infra.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Configuracao
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string valor { get; set; }
        public Nullable<int> perfil { get; set; }
        public Nullable<int> perfil_id { get; set; }
    
        public virtual Perfil Perfil1 { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
