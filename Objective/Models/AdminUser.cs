

namespace Application.Models
{
    public class AdminUser : UserBase
    {
        public override string GetRole() => "Admin";
    }
}
