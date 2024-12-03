
namespace Application.Models
{
    public class RegularUser : UserBase
    {
        public override string GetRole() => "Regular user";
    }
}
