using Mohamed_Ateto_TrailA.Models;

namespace Mohamed_Ateto_TrailA.Reposatories.Interface
{
    public interface IAuthRepo : IGenericRepo<User>
    {
        Task<User> GetUserByEmail(string email);


    }
}
