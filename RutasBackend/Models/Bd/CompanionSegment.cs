using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Representa un segmento de un trayecto en el que una usuaria fue acompañada por otra.
    /// Útil para registrar encuentros físicos parciales durante la ruta.
    /// </summary>
    [Table("CompanionSegments")]
    public class CompanionSegment
    {
        /// <summary>
        /// Identificador único del segmento de acompañamiento.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador del trayecto principal.
        /// </summary>
        [Required]
        public Guid JourneyId { get; set; }

        /// <summary>
        /// Propiedad de navegación al trayecto correspondiente.
        /// </summary>
        [ForeignKey(nameof(JourneyId))]
        public Journey? Journey { get; set; }

        /// <summary>
        /// Identificador de la usuaria que prestó el acompañamiento en este tramo.
        /// </summary>
        [Required]
        public Guid CompanionUserId { get; set; }

        /// <summary>
        /// Fecha y hora en la que comenzó el acompañamiento físico.
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Fecha y hora en la que finalizó el acompañamiento físico (si ya terminó).
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Latitud en el punto de encuentro inicial.
        /// </summary>
        public double? StartLatitude { get; set; }
        
        /// <summary>
        /// Longitud en el punto de encuentro inicial.
        /// </summary>
        public double? StartLongitude { get; set; }

        /// <summary>
        /// Latitud en el punto de separación.
        /// </summary>
        public double? EndLatitude { get; set; }
        
        /// <summary>
        /// Longitud en el punto de separación.
        /// </summary>
        public double? EndLongitude { get; set; }
    }
}
