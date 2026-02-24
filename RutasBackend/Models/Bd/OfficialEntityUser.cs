using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasBackend.Models.Bd
{
    [Table("OfficialEntityUsers")]
    public class OfficialEntityUser
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();



        public Guid OfficialEntityId { get; set; }

        [ForeignKey(nameof(OfficialEntityId))]
        public OfficialEntity OfficialEntity { get; set; }

        
        
        /// <summary>
        /// Referencia al ApplicationUser
        /// </summary>
        [Required]
        public string ApplicationUserId { get; set; } 

    }
}
