using System.ComponentModel.DataAnnotations;
namespace Cloud_Customer_Contact_Book.Models
{
    /// <summary>
    /// Group Create/Update Model.
    /// </summary>
    public class GroupCreateModel
    {
        /// <summary>
        /// Group name.
        /// </summary>
        /// <example>Family</example>
        [Required]
        public string Name { get; internal set; }
    }
}
