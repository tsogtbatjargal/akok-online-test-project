using AKOK_BlazorServer.Data;
using AKOK_BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AKOK_BlazorServer.Services
{
    public class ResultTextService : IResultTextService
    {
        private readonly FortuneDbContext _context;
        private readonly ILogger<ResultTextService> _logger;
        public ResultTextService(ILogger<ResultTextService> logger, FortuneDbContext context)
        {
            _logger = logger;
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

        public async Task<ResultText> GetResultTextAsync(int id)
        {
            return await _context.ResultTexts.FindAsync(id);
        }


        public ResultText FindById(int id)
        {            
            return _context.ResultTexts.Find(id);
        }

        public List<ResultText> GetAll()
        {
            return _context.ResultTexts.ToList();
        }

        public async Task<bool> UpdateResultTextAsync(ResultText resultText)
        {
            try
            {
                if (resultText.ID == 0)
                {
                    // If ID is 0, it means it's a new resultText, so add it instead of updating.
                    await AddResultTextAsync(resultText);
                }
                else
                {
                    // Find the existing resultText from the database.
                    var existingResultText = await _context.ResultTexts.FindAsync(resultText.ID);

                    if (existingResultText == null)
                    {
                        // If resultText doesn't exist in database, return false to indicate failure.
                        return false;
                    }

                    // Update the properties of existing resultText with the new values.
                    existingResultText.Number = resultText.Number;
                    existingResultText.HeaderText = resultText.HeaderText;
                    existingResultText.LongText = resultText.LongText;

                    // Update the database with the changes.
                    await _context.SaveChangesAsync();
                }

                // Return true to indicate success.
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception and return false to indicate failure.
                _logger.LogError(ex, "Error updating resultText.");
                return false;
            }
        }

        public async Task<bool> AddResultTextAsync(ResultText resultText)
        {
            try
            {
                // Add the new resultText to the database.
                _context.ResultTexts.Add(resultText);
                await _context.SaveChangesAsync();

                // Return true to indicate success.
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception and return false to indicate failure.
                _logger.LogError(ex, "Error adding new resultText.");
                return false;
            }
        }

        public async Task<bool> DeleteResultTextAsync(int id)
        {
            try
            {
                var resultText = await _context.ResultTexts.FindAsync(id);
                if (resultText == null)
                {
                    return false;
                }
                _context.ResultTexts.Remove(resultText);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
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
