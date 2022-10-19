using System.ComponentModel.DataAnnotations;
namespace Cloud_Customer_Contact_Book.Models
{
    /// <summary>
    /// Group Model.
    /// </summary>
    public class GroupModel
    {
        /// <summary>
        /// Group name.
        /// </summary>
        /// <example>Family</example>
        [Required]
        public object Name { get; internal set; }
        /// <summary>
        /// Group identifier.
        /// </summary>
        /// <example>321</example>
        [Required]
        public long Id { get; internal set; }
        /// <summary>
        /// Amount of members in this group.
        /// </summary>
        /// <example>7</example>
        [Required]
        public int MemberCount { get; internal set; }
    }
}
