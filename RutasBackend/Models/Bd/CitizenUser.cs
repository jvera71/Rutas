using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Representa a un usuario ciudadano anónimo en el sistema.
    /// La identidad real solo es conocida por la entidad oficial emisora del código.
    /// </summary>
    [Table("CitizenUsers")]
    public class CitizenUser
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Código único proporcionado por el ayuntamiento o entidad oficial.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// Identificador unico de la app instalada en el dispositivo
        /// </summary>
        public Guid? LocalUserProfileId { get; set; }

        /// <summary>
        /// PIN de seguridad para cancelar alarmas o acceder a funciones sensibles.
        /// </summary>
        [MaxLength(10)]
        public string? PinCode { get; set; }

        /// <summary>
        /// Tipo de interfaz de camuflaje seleccionada (Calculadora, Reproductor, etc.).
        /// </summary>
        [MaxLength(50)]
        public string? CamouflageMode { get; set; }

        /// <summary>
        /// Indica si las alertas de hardware (botón encendido, sacudida) están activadas.
        /// </summary>
        public bool HardwareAlertsEnabled { get; set; } = false;

        /// <summary>
        /// Referencia a la entidad oficial (Ayuntamiento) que gestiona a este usuario.
        /// </summary>
        public Guid? OfficialEntityId { get; set; }

        /// <summary>
        /// Indica si el usuario está activo en el sistema.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Fecha de creación del registro.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Relación con los trayectos realizados por el usuario.
        /// </summary>
        public ICollection<Journey> Journeys { get; set; } = new List<Journey>();
    }
}
