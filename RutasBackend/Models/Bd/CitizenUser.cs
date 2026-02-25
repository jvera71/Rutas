using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    #nullable enable
    /// <summary>
    /// Representa a un usuario ciudadano anónimo en el sistema.
    /// La identidad real del ciudadano solo es conocida por la entidad oficial (ayuntamiento u organización) 
    /// que emitió su código de acceso único.
    /// </summary>
    [Table("CitizenUsers")]
    [Index(nameof(Code),IsUnique = true)]
    public class CitizenUser
    {
        /// <summary>
        /// Identificador único del registro del ciudadano en la base de datos.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Código único de 8 caracteres proporcionado por el ayuntamiento o entidad oficial.
        /// Este código es la única forma de acceso del ciudadano y mantiene su anonimato.
        /// </summary>
        [Required]
        [MaxLength(8)]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Identificador único del perfil local en la aplicación móvil instalada en el dispositivo.
        /// </summary>
        public Guid? LocalUserProfileId { get; set; }

        /// <summary>
        /// PIN de seguridad de hasta 10 caracteres que el usuario utiliza para cancelar falsas alarmas 
        /// o acceder a funciones de configuración sensibles.
        /// </summary>
        [MaxLength(10)]
        public string? PinCode { get; set; }

        /// <summary>
        /// Indica el tipo de interfaz de camuflaje activa (Calculadora, Reproductor de música, etc.) 
        /// para ocultar la funcionalidad real de seguridad.
        /// </summary>
        [MaxLength(50)]
        public string? CamouflageMode { get; set; }

        /// <summary>
        /// Indica si están habilitadas las alertas mediante botones de hardware o sacudidas del dispositivo.
        /// </summary>
        public bool HardwareAlertsEnabled { get; set; } = false;

        /// <summary>
        /// Identificador de la entidad oficial (ej. Ayuntamiento de Barcelona) que gestiona y validó a este usuario.
        /// </summary>
        public Guid OfficialEntityId { get; set; }

        /// <summary>
        /// Propiedad de navegación a la entidad oficial.
        /// </summary>
        [ForeignKey(nameof(OfficialEntityId))]
        public OfficialEntity? OfficialEntity { get; set; }

        /// <summary>
        /// Indica si la cuenta del ciudadano está actualmente activa y autorizada para el sistema.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Fecha y hora en la que se registró el usuario en el sistema.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Colección de trayectos de seguridad registrados por este usuario.
        /// </summary>
        public ICollection<Journey> Journeys { get; set; } = new List<Journey>();

        /// <summary>
        /// Registro histórico de acciones realizadas sobre este usuario (auditoría).
        /// </summary>
        public ICollection<CitizenUserAction> CitizenUserActions { get; set; } = new List<CitizenUserAction>();
    }
}
