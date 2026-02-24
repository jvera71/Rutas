using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Representa un pin de reporte anónimo sobre el estado de la infraestructura urbana.
    /// Utilizado para generar mapas de calor para el ayuntamiento.
    /// </summary>
    [Table("ReportPins")]
    public class ReportPin
    {
        /// <summary>
        /// Identificador único del reporte.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador (opcional) del usuario que reporta. Se mantiene el anonimato.
        /// </summary>
        public Guid? CitizenUserId { get; set; } 

        /// <summary>
        /// Latitud del punto reportado.
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitud del punto reportado.
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// Tipo de incidencia (Falta de iluminación, Presencia intimidante, etc.).
        /// </summary>
        [Required]
        public RutasAppBackend.Enums.IssueType IssueType { get; set; } 

        /// <summary>
        /// Fecha y hora del reporte.
        /// </summary>
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indica si la incidencia ha sido resuelta o evaluada por las autoridades.
        /// </summary>
        public bool IsResolved { get; set; } = false;
    }
}
