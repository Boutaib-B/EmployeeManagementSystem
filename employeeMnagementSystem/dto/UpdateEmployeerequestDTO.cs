using Microsoft.Owin.BuilderProperties;

namespace WebApplication1.dto
{
    public class UpdateEmployeerequestDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public AddressDTO? Adress { get; set; }
    }
}
