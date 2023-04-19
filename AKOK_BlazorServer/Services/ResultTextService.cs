using AKOK_BlazorServer.Data;
using AKOK_BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AKOK_BlazorServer.Services
{
    public class ResultTextService : IResultTextService
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

        public bool AddUpdate(ResultText resultText)
        {
            try
            {
                if (resultText.ID == 0)
                    _context.ResultTexts.Add(resultText);
                else
                    _context.ResultTexts.Update(resultText);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var resultText = FindById(id);
                if (resultText == null)
                    return false;
                _context.ResultTexts.Remove(resultText);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public ResultText FindByNumber(int? number)
        {
            return _context.ResultTexts.FirstOrDefault(rt => rt.Number == number);
        }

        public ResultText FindById(int id)
        {            
            return _context.ResultTexts.Find(id);
        }

        public List<ResultText> GetAll()
        {
            return _context.ResultTexts.ToList();
        }

        //public async Task<ResultText> GetResultText(int number)
        //{
        //    return await _context.ResultTexts.FirstOrDefaultAsync(rt => rt.Number == number);
        //}

        //public async Task<List<ResultText>> GetResultTexts()
        //{
        //    return await _context.ResultTexts.ToListAsync();
        //}

        //public async Task CreateResultText(ResultText resultText)
        //{
        //    _context.ResultTexts.Add(resultText);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateResultText(ResultText resultText)
        //{
        //    _context.Entry(resultText).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteResultText(ResultText resultText)
        //{
        //    _context.ResultTexts.Remove(resultText);
        //    await _context.SaveChangesAsync();
        //}


    }
}
