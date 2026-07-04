using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Update(Comment comment);
    }
}