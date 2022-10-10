using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class GetAllCounty
    {
        public class Query : IRequest<List<CountyResponse>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<CountyResponse>>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public QueryHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<List<CountyResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Result = await _TblLocationRepo.GetAllCountyAsync();

                if (Result == null)
                    return null;

                return Result.Select(p => CountyMapper.Mapper.Map<CountyResponse>(p)).ToList();
            }

        }
    }
}
