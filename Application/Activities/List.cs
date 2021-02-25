using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<ActivityDto>> { }

        public class Handler : IRequestHandler<Query, List<ActivityDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<ActivityDto>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var activities = await _context.Activities
                .ToListAsync();

                return _mapper.Map<List<Activity>,List<ActivityDto>>(activities);
            }
            //private readonly ILogger<List> _logger;
            // public Handler(DataContext context, ILogger<List> logger)
            //_logger = logger;
            // public async Task<List<Activity>> Handle(Query request,
            //     CancellationToken cancellationToken)
            // {
            //     try
            //     {
            //         for (var i = 0; i < 10; i++)
            //         {
            //             cancellationToken.ThrowIfCancellationRequested();
            //             await Task.Delay(1000, cancellationToken);
            //             _logger.LogInformation($"Task {i} has completed.");
            //         }
            //     }
            //     catch (Exception ex) when (ex is TaskCanceledException)
            //     {
            //         _logger.LogInformation($"Task is cancelled");
            //     }
            //     var activities = await _context.Activities.ToListAsync(cancellationToken);
            //     return activities;
            // }
        }
    }
}

