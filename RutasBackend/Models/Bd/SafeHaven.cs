using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Lugares de refugio seguros (negocios locales certificados) donde las usuarias 
    /// pueden solicitar asistencia.
    /// </summary>
    [Table("SafeHavens")]
    public class SafeHaven
    {
        /// <summary>
        /// Identificador único del refugio.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Nombre comercial del establecimiento.
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// Tipo de establecimiento (Farmacia, Gasolinera, Bar, etc.).
        /// </summary>
        [Required]
        public RutasAppBackend.Enums.HavenCategory Category { get; set; } 

        /// <summary>
        /// Latitud del establecimiento.
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitud del establecimiento.
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// Indica si el refugio está disponible las 24 horas.
        /// </summary>
        public bool Is24Hours { get; set; } = false;

        /// <summary>
        /// Indica si el refugio está actualmente activo en el programa de seguridad.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
