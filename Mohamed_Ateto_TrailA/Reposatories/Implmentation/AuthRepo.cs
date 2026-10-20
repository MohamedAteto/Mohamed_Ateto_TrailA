using Microsoft.EntityFrameworkCore;
using Mohamed_Ateto_TrailA.Data;
using Mohamed_Ateto_TrailA.Models;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Reposatories.Implmentation
{
    public class AuthRepo : GenericRepo<User>, IAuthRepo
    {
        private readonly AppDbContext _context;

        public AuthRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var item =  await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
            return item;

        }
    }
}
