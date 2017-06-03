namespace ProyectoCine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cartelera
    {
        [Key]
        public int IdCartelera { get; set; }

        public int IdSede { get; set; }

        public int IdPelicula { get; set; }

        public int HoraInicio { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int NumeroSala { get; set; }

        public int IdVersion { get; set; }

        public bool Lunes { get; set; }

        public bool Martes { get; set; }

        public bool Miercoles { get; set; }

        public bool Jueves { get; set; }

        public bool Viernes { get; set; }

        public bool Sabado { get; set; }

        public bool Domingo { get; set; }

        public DateTime FechaCarga { get; set; }

        public virtual Pelicula Pelicula { get; set; }

        public virtual Sede Sede { get; set; }

        public virtual Versione Versione { get; set; }
    }
}
