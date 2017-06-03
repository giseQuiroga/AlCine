namespace ProyectoCine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        public int IdSede { get; set; }

        public int IdVersion { get; set; }

        public int IdPelicula { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public int IdTipoDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroDocumento { get; set; }

        public int CantidadEntradas { get; set; }

        public DateTime FechaCarga { get; set; }

        public virtual Pelicula Pelicula { get; set; }

        public virtual Sede Sede { get; set; }

        public virtual TiposDocumento TiposDocumento { get; set; }

        public virtual Versione Versione { get; set; }
    }
}
