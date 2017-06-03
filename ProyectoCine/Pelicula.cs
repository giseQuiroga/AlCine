namespace ProyectoCine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pelicula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pelicula()
        {
            Carteleras = new HashSet<Cartelera>();
            Reservas = new HashSet<Reserva>();
        }

        [Key]
        public int IdPelicula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(750)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(300)]
        public string Imagen { get; set; }

        public int IdCalificacion { get; set; }

        public int IdGenero { get; set; }

        public int Duracion { get; set; }

        public DateTime FechaCarga { get; set; }

        public virtual Calificacione Calificacione { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cartelera> Carteleras { get; set; }

        public virtual Genero Genero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
