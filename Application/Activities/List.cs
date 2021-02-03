using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.ToListAsync();
                return activities;
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

