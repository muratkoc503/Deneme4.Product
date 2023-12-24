using Deneme4.Yugioh.Models;

namespace Deneme4.Yugioh.Repositories.Interfaces
{
    public interface IYugiohRepository
    {
        Task<IEnumerable<YugiohCard>> GetCards();
        Task<YugiohCard> GetCard(int id);
        Task Create(YugiohCard card);
        Task<bool> Update(YugiohCard cars);
        Task<bool> Delete(int id);
    }
}
