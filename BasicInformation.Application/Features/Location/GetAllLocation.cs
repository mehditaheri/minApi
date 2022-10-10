using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class GetAllLocation
    {
        public class Query : IRequest<List<LocationResponse>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<LocationResponse>>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public QueryHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<List<LocationResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Result = await _TblLocationRepo.GetAllAsync();

                if (Result == null)
                    return null;

                return Result.Select(p => LocationMapper.Mapper.Map<LocationResponse>(p)).ToList();
            }

        }
    }
}
