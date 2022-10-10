using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class GetAllRuralDistrict
    {
        public class Query : IRequest<List<RuralDistrictResponse>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<RuralDistrictResponse>>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public QueryHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<List<RuralDistrictResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Result = await _TblLocationRepo.GetAllRuralDistrictAsync();

                if (Result == null)
                    return null;

                return Result.Select(p => RuralDistrictMapper.Mapper.Map<RuralDistrictResponse>(p)).ToList();
            }

        }
    }
}
