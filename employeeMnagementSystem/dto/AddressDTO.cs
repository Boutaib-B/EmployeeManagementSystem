namespace WebApplication1.dto
{
    public class AddressDTO
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }

    public class AdressForDisplay : AddressDTO
    {
        public int AddressId { get; set; }
    }
}
