using AutoMapper;
using Driver.DataService.Repositories.Interfaces;
using Driver.Entities.Dtos.Responses;
using DriverAPI.Queries;
using MediatR;

namespace DriverAPI.Handlers
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriversHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.All();
            return _mapper.Map<IEnumerable<GetDriverResponse>>(driver);

        }
    }
}
