using Deneme4.Yugioh.Data;
using Deneme4.Yugioh.Models;
using Deneme4.Yugioh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deneme4.Yugioh.Repositories
{
    public class YugiohRepository : IYugiohRepository
    {
        private readonly AppDbContext _context;

        public YugiohRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(YugiohCard product)
        {
            await _context.Yugioh.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Yugioh.FindAsync(id);
            if (product != null)
            {
                _context.Yugioh.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<YugiohCard> GetCard(int id)
        {
            return await _context.Yugioh.FindAsync(id);
        }

        public async Task<IEnumerable<YugiohCard>> GetCards()
        {
            return await _context.Yugioh.ToListAsync();
        }

        public async Task<bool> Update(YugiohCard card)
        {
            var existingProduct = await _context.Yugioh.FindAsync(card.Id);

            if (existingProduct == null)
                return false;

            _context.Entry(existingProduct).CurrentValues.SetValues(card);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
