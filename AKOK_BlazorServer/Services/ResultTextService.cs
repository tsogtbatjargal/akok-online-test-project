using AKOK_BlazorServer.Data;
using AKOK_BlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AKOK_BlazorServer.Services
{
    public class ResultTextService
    {
        private readonly FortuneDbContext _context;
        public ResultTextService(FortuneDbContext context)
        {
            _context = context;
        }
        public FortuneNumber FortuneNumberResult { get; set; }
        public Person PersonResult { get; set; }

        public void SetValueForPerson (Person person)
        {
            PersonResult = new Person()
            {
               FirstName = person.FirstName,
               MiddleName = person.MiddleName,
               LastName = person.LastName,
               DateOfBirth = person.DateOfBirth,
               Email = person.Email,
            };
        }

        public void SetValueForFeeConfirmation(FortuneNumber feeConfirmation)
        {
            FortuneNumberResult = new FortuneNumber()
            {                
                DynamicsOfLifeNumber = feeConfirmation.DynamicsOfLifeNumber,
                ResultNameNumber = feeConfirmation.ResultNameNumber,
                ResultNameNumberHybrid = feeConfirmation.ResultNameNumberHybrid,
            };
        }

        public async Task<ResultText> GetResultText(int number)
        {
            return await _context.ResultTexts.FirstOrDefaultAsync(rt => rt.Number == number);
        }

        public async Task<List<ResultText>> GetResultTexts()
        {
            return await _context.ResultTexts.ToListAsync();
        }

        public async Task CreateResultText(ResultText resultText)
        {
            _context.ResultTexts.Add(resultText);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResultText(ResultText resultText)
        {
            _context.Entry(resultText).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResultText(ResultText resultText)
        {
            _context.ResultTexts.Remove(resultText);
            await _context.SaveChangesAsync();
        }
    }
}
