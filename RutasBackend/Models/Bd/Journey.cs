using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Representa un trayecto o viaje realizado por un usuario.
    /// Los datos de geolocalización son efímeros y deben eliminarse al finalizar el viaje,
    /// a menos que se registre un reporte de incidente.
    /// </summary>
    [Table("Journeys")]
    public class Journey
    {
        /// <summary>
        /// Identificador único del trayecto.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador del usuario que realiza el trayecto.
        /// </summary>
        [Required]
        public Guid CitizenUserId { get; set; }

        /// <summary>
        /// Propiedad de navegación al usuario ciudadano.
        /// </summary>
        [ForeignKey(nameof(CitizenUserId))]
        public CitizenUser? CitizenUser { get; set; }

        /// <summary>
        /// Latitud del punto de origen.
        /// </summary>
        public double StartLatitude { get; set; }
        
        /// <summary>
        /// Longitud del punto de origen.
        /// </summary>
        public double StartLongitude { get; set; }

        /// <summary>
        /// Latitud del destino final.
        /// </summary>
        public double DestinationLatitude { get; set; }
        
        /// <summary>
        /// Longitud del destino final.
        /// </summary>
        public double DestinationLongitude { get; set; }

        /// <summary>
        /// Fecha y hora de inicio del trayecto.
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        
        /// <summary>
        /// Fecha y hora de finalización del trayecto.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Indica si el trayecto está en curso.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Indica si el usuario optó por la "Ruta Segura" sugerida.
        /// </summary>
        public bool UsedSafeRoute { get; set; } = true;

        /// <summary>
        /// Segmentos del trayecto en los que la usuaria estuvo acompañada físicamente.
        /// </summary>
        public System.Collections.Generic.ICollection<CompanionSegment> CompanionSegments { get; set; } = new System.Collections.Generic.List<CompanionSegment>();
    }
}
