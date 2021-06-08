using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SensoryTask.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        //[RegularExpression(@"^\d{9}$", ErrorMessage = "Id Number not valid")]
        [Required(ErrorMessage = "ID Number is required")]
        public int IdNumber { get; set; }

        //[RegularExpression(@"^[א-תa-zA-Z''-'\s]{1,20}$", ErrorMessage = "First name contains not allowed characters")]
        [Required(ErrorMessage = "First name is required")]
        //[StringLength(20, ErrorMessage = "First name can't be longer than 20 characters")]
        public string FirstName { get; set; }

        //[RegularExpression(@"^[א-תa-zA-Z''-'\s]{1,20}$", ErrorMessage = "Last name contains not allowed characters")]
        [Required(ErrorMessage = "Last name is required")]
        // [StringLength(20, ErrorMessage = "Last name can't be longer than 20 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Profession is required")]
        public int ProfessionId { get; set; }

        [JsonIgnore]
        public Profession Profession { get; set; }

        [NotMapped]
        public string ProfessionName => Profession?.ProfessionName;

    }
}
