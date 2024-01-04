using AutoMapper;
using Driver.DataService.Repositories.Interfaces;
using Driver.Entities.DbSet;
using Driver.Entities.Dtos.Requests;
using DriverAPI.Commands;
using MediatR;

namespace DriverAPI.Handlers
{
    public class DeleteDriverInfoHandler : IRequestHandler<DeleteDriverInfoRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDriverInfoHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDriverInfoRequest request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

            if (driver == null)
                return false;

            await _unitOfWork.Drivers.Delete(request.DriverId);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
