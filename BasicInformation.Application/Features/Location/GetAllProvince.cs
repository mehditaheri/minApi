using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class GetAllProvince
    {
        public class Query : IRequest<List<ProvinceResponse>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<ProvinceResponse>>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public QueryHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<List<ProvinceResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Result = await _TblLocationRepo.GetAllProvinceAsync();

                if (Result == null)
                    return null;

                return Result.Select(p => ProvinceMapper.Mapper.Map<ProvinceResponse>(p)).ToList();
            }

        }
    }
}
