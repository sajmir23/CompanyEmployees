using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service
{
    internal sealed class ReviewService : IReviewService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public ReviewService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _loggerManager = logger;
            _repositoryManager = repository;
            _mapper = mapper;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            var reviews = _repositoryManager.Review.GetAllReviews(false);

            return reviews;
        }

        public Review AddReview (ReviewDto reviewDto)
        {

            var reviewEntity = _mapper.Map<Review>(reviewDto);
            _repositoryManager.Review.CreateReview(reviewEntity);
            _repositoryManager.Save();

            return reviewEntity;
        }
    }
}
