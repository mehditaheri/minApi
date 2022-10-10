using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class GetAllVillage
    {
        public class Query : IRequest<List<VillageResponse>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<VillageResponse>>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public QueryHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<List<VillageResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Result = await _TblLocationRepo.GetAllVillageAsync();

                if (Result == null)
                    return null;

                return Result.Select(p => VillageMapper.Mapper.Map<VillageResponse>(p)).ToList();
            }

        }
    }
}
