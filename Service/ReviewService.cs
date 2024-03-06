using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
