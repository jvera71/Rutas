using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    /// <summary>
    /// Representa una entidad oficial (como un Ayuntamiento) que gestiona el sistema en su localidad.
    /// </summary>
    [Table("OfficialEntities")]
    public partial class OfficialEntity
    {
        /// <summary>
        /// Identificador único de la entidad.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Nombre oficial de la entidad.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Colección de usuarios administrativos vinculados a esta entidad.
        /// </summary>
        public ICollection<OfficialEntityUser> OfficialEntityUsers { get; set; }
    }
}