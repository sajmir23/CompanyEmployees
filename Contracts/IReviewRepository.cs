using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReviewRepository
    {
       IEnumerable<Review> GetAllReviews(bool trackChanges);   

       void CreateReview(Review review);  
    }
}
