namespace Mohamed_Ateto_TrailA.Reposatories.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        Task<ICollection<T>> GetAll();

        Task Create(T entity);
        Task Delete(int id );

        Task Update(int id , T entity);
       Task<T> GetById(int id);
    }
}
