using Driver.Entities.Dtos.Responses;
using MediatR;

namespace DriverAPI.Queries
{
    public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
    {
    }
}
