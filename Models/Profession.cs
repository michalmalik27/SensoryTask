using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SensoryTask.Models
{
    public class Profession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfessionId { get; set; }

        [Required(ErrorMessage = "Profession name is required")]
        [MaxLength(50)]
        public string ProfessionName { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Person> Persons { get; set; }
    }
}
