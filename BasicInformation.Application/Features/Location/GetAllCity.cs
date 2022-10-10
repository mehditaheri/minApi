using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class GetAllCity
    {
        public class Query : IRequest<List<CityResponse>>
        {
            public long ProvinceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<CityResponse>>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public QueryHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<List<CityResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Result = await _TblLocationRepo.GetAllCityAsync(request.ProvinceId);

                if (Result == null)
                    return null;

                return Result.Select(p => CityMapper.Mapper.Map<CityResponse>(p)).ToList();
            }

        }
    }
}
