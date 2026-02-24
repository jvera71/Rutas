using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasApp.Models
{
    /// <summary>
    /// Contacto de emergencia almacenado localmente en el dispositivo.
    /// Los datos nunca se sincronizan con el servidor central para preservar el anonimato.
    /// </summary>
    [Table("EmergencyContacts")]
    public class EmergencyContact
    {
        /// <summary>
        /// Identificador único local del contacto.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Nombre del contacto de confianza.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; } = null!;

        /// <summary>
        /// Número de teléfono para el envío automático de SMS de llegada o alerta.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public required string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Indica si se debe enviar un SMS automático al llegar al destino.
        /// </summary>
        public bool SendSmsOnArrival { get; set; } = true;
    }
}
