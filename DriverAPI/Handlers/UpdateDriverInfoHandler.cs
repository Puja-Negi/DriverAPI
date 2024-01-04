using AutoMapper;
using Driver.DataService.Repositories.Interfaces;
using Driver.Entities.DbSet;
using DriverAPI.Commands;
using MediatR;

namespace DriverAPI.Handlers
{
    public class UpdateDriverInfoHandler : IRequestHandler<UpdateDriverInfoRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverInfoHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateDriverInfoRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Driver.Entities.DbSet.Driver>(request.Driver);

            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
