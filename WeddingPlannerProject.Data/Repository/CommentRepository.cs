using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }
    }
}