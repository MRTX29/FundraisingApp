using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Repositories;

namespace FundraisingAppProcessor.Services;

    public class MoneyBoxService(IMoneyBoxRepository boxRepository) : IMoneyBoxService
    {
        public async Task<MoneyBox> CreateMoneyBoxAsync(DateTime? dateReturned)
        {
            var newBox = new MoneyBox
            {
                DateReturned = dateReturned,
                ApprovedByAdmin = false
            };

            return await boxRepository.AddMoneyBoxAsync(newBox);
        }

        public async Task<List<MoneyBox>> GetAllMoneyBoxesAsync() => await boxRepository.GetAllMoneyBoxesAsync();

        public async Task<MoneyBox?> GetMoneyBoxByIdAsync(int id) => await boxRepository.GetMoneyBoxByIdAsync(id);

        public async Task<MoneyBox> ApproveMoneyBoxAsync(int id)
        {
            var box = await boxRepository.GetMoneyBoxByIdAsync(id);
            if (box == null)
            {
                throw new Exception("MoneyBox not found");
            }

            box.ApprovedByAdmin = true;
            await boxRepository.UpdateMoneyBoxAsync(box);
            return box;
        }

        public async Task<MoneyBox> UpdateDenominationsAsync(int boxId, Denominations denominations)
        {
            var box = await boxRepository.GetMoneyBoxByIdAsync(boxId);
            if (box == null)
            {
                throw new Exception("MoneyBox not found");
            }

            box.Denominations = denominations;
            await boxRepository.UpdateMoneyBoxAsync(box);
            return box;
        }
    }