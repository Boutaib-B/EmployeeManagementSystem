using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> CreateAddressAsync(Address Addressdomainmodel);
        Task<Address> UpdateAddressAsync(int id, Address Addressdomainmodel);
        Task<Address> DeleteAddressAsync(int id);
    }
}
