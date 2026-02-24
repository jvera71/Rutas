using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Representa una alerta de pánico activada por un usuario en situación de riesgo.
    /// Notifica en tiempo real a autoridades y usuarios cercanos a través de SignalR.
    /// </summary>
    [Table("PanicAlerts")]
    public class PanicAlert
    {
        /// <summary>
        /// Identificador único de la alerta.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador del usuario que activó la alerta.
        /// </summary>
        [Required]
        public Guid CitizenUserId { get; set; }

        /// <summary>
        /// Propiedad de navegación al usuario ciudadano.
        /// </summary>
        [ForeignKey(nameof(CitizenUserId))]
        public CitizenUser? CitizenUser { get; set; }

        /// <summary>
        /// Latitud en el momento de la activación.
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitud en el momento de la activación.
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// Fecha y hora de activación del modo pánico.
        /// </summary>
        public DateTime TriggeredAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Método de activación (Botón de pánico, Dead Man Switch, Hardware, etc.).
        /// </summary>
        [Required]
        public RutasAppBackend.Enums.TriggerMethod TriggerMethod { get; set; } = RutasAppBackend.Enums.TriggerMethod.ManualButton; 

        /// <summary>
        /// Indica si la alerta sigue activa o ha sido desactivada mediante PIN.
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        /// <summary>
        /// Ruta o identificador del archivo de grabación A/V encriptado enviado a las autoridades.
        /// </summary>
        [MaxLength(500)]
        public string? EncryptedMediaLocation { get; set; } 
    }
}
