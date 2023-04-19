using AKOK_BlazorServer.Models;

namespace AKOK_BlazorServer.Services
{
    public interface IResultTextService
    {
        bool AddUpdate(ResultText resultText);
        bool Delete(int id);
        ResultText FindById(int id);
        ResultText FindByNumber(int? id);
        List<ResultText> GetAll();
    }
}
