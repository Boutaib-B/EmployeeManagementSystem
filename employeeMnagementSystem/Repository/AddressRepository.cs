using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public AddressRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Address> CreateAddressAsync(Address addr)
        {
            await _context.Addresses.AddAsync(addr);
            await _context.SaveChangesAsync();
            return addr;

        }

        public async Task<Address> DeleteAddressAsync(int id)
        {
            var addrToDelete = await _context.Addresses.FindAsync(id);

            if (addrToDelete != null)
            {
                _context.Addresses.Remove(addrToDelete);
                await _context.SaveChangesAsync();
            }

            return addrToDelete;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }
        public async Task<Address> GetAddressByIdAsync(int add_id)
        {
            var addr = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressId == add_id);
            //Include(_ => _.Address)
            // .Include(_ => _.Department)
            return addr;
        }
        public async Task<Address> UpdateAddressAsync(int id, Address addr_update)
        {
            var existingaddr = await _context.Addresses.Include(_ => _.Employee).FirstOrDefaultAsync(x => x.AddressId == id);


            if (existingaddr != null)
            {
                existingaddr.ZipCode = addr_update.ZipCode;
                existingaddr.Street = addr_update.Street;
                existingaddr.State = addr_update.State;
                existingaddr.City = addr_update.City;
                existingaddr.Employee = addr_update.Employee;

                // Mettez à jour les autres propriétés

                await _context.SaveChangesAsync();
            }

            return existingaddr;
        }


    }
}
