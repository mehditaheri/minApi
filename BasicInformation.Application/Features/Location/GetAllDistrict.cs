using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class GetAllDistrict
    {
        public class Query : IRequest<List<DistrictResponse>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<DistrictResponse>>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public QueryHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<List<DistrictResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Result = await _TblLocationRepo.GetAllDistrictAsync();

                if (Result == null)
                    return null;

                return Result.Select(p => DistrictMapper.Mapper.Map<DistrictResponse>(p)).ToList();
            }

        }
    }
}
