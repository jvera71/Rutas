using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasApp.Models
{
    /// <summary>
    /// Perfil de usuario almacenado localmente en el dispositivo.
    /// </summary>
    [Table("LocalUserProfiles")]
    public class LocalUserProfile
    {
        /// <summary>
        /// Identificador único local del perfil de usuario.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Código de usuario anónimo proporcionado por el ayuntamiento.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string UserCode { get; set; } = null!;

        /// <summary>
        /// PIN de seguridad necesario para cancelar alarmas.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public required string SecurityPin { get; set; } = null!;
    }
}
