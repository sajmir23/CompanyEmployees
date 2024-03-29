﻿using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IReviewService
    {
        public IEnumerable<Review> GetAllReviews();

        public Review AddReview(ReviewDto reviewDto);

    }
}
