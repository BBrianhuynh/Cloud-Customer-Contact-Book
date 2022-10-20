using System.ComponentModel.DataAnnotations;
namespace Cloud_Customer_Contact_Book.Models
{
    public class ContactCreateModel
    {
        /// <summary>
        /// Contact first mame.
        /// </summary>
        /// <example>Will</example>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Contact last mame.
        /// </summary>
        /// <example>Smith</example>
        public string LastName { get; set; }
        /// <summary>
        /// Contact phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
        
    }
}
