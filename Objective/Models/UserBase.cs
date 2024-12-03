

namespace Application.Models
{
    public abstract class UserBase
    {
        public int Id { get; set; } 
        public required string Name { get; set; }    
        public required string Email { get; set; }
        public abstract string GetRole();
    }
}
