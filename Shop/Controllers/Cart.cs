using Shop.Models;

namespace Shop.Controllers
{
    public class Cart
    {
        private readonly PhTechContext _context;

        public Cart(PhTechContext context)
        {
            _context = context;
        }
    }
}
