using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Vincula un usuario del sistema de identidad (ApplicationUser) con una entidad oficial específica.
    /// </summary>
    [Table("OfficialEntityUsers")]
    [Index(nameof(ApplicationUserId))]
    public class OfficialEntityUser
    {
        /// <summary>
        /// Identificador único del vínculo.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador de la entidad oficial asociada.
        /// </summary>
        public Guid OfficialEntityId { get; set; }

        /// <summary>
        /// Propiedad de navegación a la entidad oficial.
        /// </summary>
        [ForeignKey(nameof(OfficialEntityId))]
        public OfficialEntity OfficialEntity { get; set; }

        /// <summary>
        /// Referencia al ApplicationUser (Identity) mediante su Id.
        /// </summary>
        [Required]
        public string ApplicationUserId { get; set; } 
    }
}
