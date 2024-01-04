using Driver.Entities.Dtos.Requests;
using MediatR;

namespace DriverAPI.Commands
{
    public class UpdateDriverInfoRequest : IRequest<bool>
    {
        public UpdateDriverRequest Driver { get; }
        public UpdateDriverInfoRequest(UpdateDriverRequest driver)
        {
            Driver = driver;
        }
    }
}
