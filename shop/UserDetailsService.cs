using shop.Data;
using shop.models;

namespace shop
{
    public class UserDetailsService
    {
        private readonly DataContext _context;

        public UserDetailsService(DataContext context)
        {
            _context = context;
        }

        public UserDetailsDto GetUserDetailsById(int userId)
        {
            // Fetch user details by user ID
            var user = _context.ShopUsers.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                return null;
            }

            return new UserDetailsDto
            {
                FirstName = user.FirstName,
               
            };
        }
    }

}
