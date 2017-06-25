//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Cartelera
    {
        public int IdCartelera { get; set; }
        [DisplayName("Sede")]
        public int IdSede { get; set; }
        [DisplayName("Pelicula")]
        public int IdPelicula { get; set; }
        [DisplayName("Hora de Inicio")]
        public int HoraInicio { get; set; }
        [DisplayName("Inicio de cartelera")]
        public System.DateTime FechaInicio { get; set; }
        [DisplayName("Fin de Cartelera")]
        public System.DateTime FechaFin { get; set; }
        [DisplayName("Numero de Sala")]
        public int NumeroSala { get; set; }
        [DisplayName("Version")]
        public int IdVersion { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        [DisplayName("Fecha de Carga")]
        public System.DateTime FechaCarga { get; set; }
        public virtual Pelicula Pelicula { get; set; }
        public virtual Sede Sede { get; set; }
        public virtual Versione Versione { get; set; }
    }
}
