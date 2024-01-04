using AutoMapper;
using Driver.DataService.Repositories.Interfaces;
using Driver.Entities.DbSet;
using Driver.Entities.Dtos.Requests;
using Driver.Entities.Dtos.Responses;
using DriverAPI.Commands;
using MediatR;

namespace DriverAPI.Handlers
{
    public class GetDriverInfoHandler : IRequestHandler<CreateDriverInfoRequest, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverInfoHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetDriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver.Entities.DbSet.Driver>(request.DriverRequest);

            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<GetDriverResponse>(driver);
        }
    }
}
