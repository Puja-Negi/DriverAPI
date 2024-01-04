using MediatR;

namespace DriverAPI.Commands
{
    public class DeleteDriverInfoRequest : IRequest<bool>
    {
        public Guid DriverId { get; }
        public DeleteDriverInfoRequest(Guid driverId)
        {

            DriverId = driverId;

        }
    }
}
