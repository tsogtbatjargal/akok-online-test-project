using AKOK_BlazorServer.Models;

namespace AKOK_BlazorServer.Services
{
    public interface IResultTextService
    {
        bool Delete(int id);
        ResultText FindById(int id);
        ResultText FindByNumber(int? id);
        List<ResultText> GetAll();
        Task<bool> UpdateResultTextAsync(ResultText resultText);
        Task<ResultText> GetResultTextAsync(int id);
        Task<bool> AddResultTextAsync(ResultText resultText);
        Task<bool> DeleteResultTextAsync(int id);
    }
}
