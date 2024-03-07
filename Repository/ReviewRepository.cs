using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Review> GetAllReviews(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();

        public void CreateReview(Review review) => Create(review);

    }

}
