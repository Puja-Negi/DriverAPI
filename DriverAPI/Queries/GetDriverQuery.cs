using Driver.Entities.Dtos.Responses;
using MediatR;

namespace DriverAPI.Queries
{
    public class GetDriverQuery : IRequest<GetDriverResponse>
    {
        public Guid DriverId { get; }

        public GetDriverQuery(Guid driverId)
        {
            DriverId = DriverId;
        }
    }
}
