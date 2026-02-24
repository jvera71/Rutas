using Microsoft.EntityFrameworkCore;
using RutasAppBackend.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    
    /// <summary>
    /// Representa una acción o auditoría realizada sobre un usuario ciudadano por una entidad oficial.
    /// </summary>
    [Table("CitizenUserActions")]  
    public class CitizenUserAction
    {
        /// <summary>
        /// Identificador único de la acción.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador del usuario ciudadano sobre el que se realiza la acción.
        /// </summary>
        public Guid CitizenUserId { get; set; }

        /// <summary>
        /// Relación con el usuario ciudadano.
        /// </summary>
        [ForeignKey(nameof(CitizenUserId))]
        public CitizenUser CitizenUser { get; set; }

        /// <summary>
        /// Identificador del usuario de la entidad oficial que realizó la acción.
        /// </summary>
        public Guid? OfficialEntityUserId { get; set; }

        /// <summary>
        /// Relación con el usuario de la entidad oficial.
        /// </summary>
        [ForeignKey(nameof(OfficialEntityUserId))]
        public OfficialEntityUser OfficialEntityUser { get; set; }

        /// <summary>
        /// Tipo de acción realizada (Creación, Visualización, etc.).
        /// </summary>
        public CitizenUserActionType CitizenUserActionType {  get; set; }

        /// <summary>
        /// Fecha y hora en la que se registró la acción.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
