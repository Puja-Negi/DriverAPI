using Driver.Entities.Dtos.Requests;
using Driver.Entities.Dtos.Responses;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace DriverAPI.Commands
{
    public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
    {
        public CreateDriverRequest DriverRequest { get; }

        public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}
