// PSEUDOCODE / DETAILED PLAN
// 1. Create a new `User` model class in a `Models` namespace so it can be reused across the project.
// 2. Include necessary data annotations: [Key], [Required], [MaxLength] to match existing constraints.
// 3. Add XML comments to document properties and a remark about password hashing for production.
// 4. Keep the class minimal and immutable-friendly (auto-properties with init where appropriate).
// 5. Ensure nullable reference types are respected (string properties non-nullable with default null-forgiving).
//
// This file provides the context user model used by the application's DbContext and services.
// Move/consume this model from `UserSegment.Models` where needed (e.g., in `AppDbContext` or services).

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserSegment.Models
{
    /// <summary>
    /// Represents an application user stored in the database.
    /// </summary>
    [Table("Users")]
    public class User : BaseModel
    { 

        /// <summary>
        /// Unique username for login.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Password. In production this should store a salted &amp; hashed password, not plain text.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Password { get; set; } = null!;
    }
}