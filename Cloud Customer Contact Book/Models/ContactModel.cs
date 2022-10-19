using System.ComponentModel.DataAnnotations;
namespace Cloud_Customer_Contact_Book.Models
{
    /// <summary>
    /// Contact Model.
    /// </summary>
    public class ContactModel
    {
        
        /// Contact phone number.
        /// </summary>
        /// <example>+10987654321</example>
        public string PhoneNumber { get; internal set; }
        /// <summary>
        /// Contact identifier.
        /// </summary>
        /// /// <example>123</example>
        public long Id { get; internal set; }
        /// <summary>
        /// Contact first mame.
        /// </summary>
        /// <example>Will</example>
        [Required]
        public object FirstName { get; internal set; }
        /// <summary>
        /// Contact last mame.
        /// </summary>
        /// <example>Smith</example>
        public object LastName { get; internal set; }
    }
}
