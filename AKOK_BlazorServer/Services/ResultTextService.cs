using AKOK_BlazorServer.Models;

namespace AKOK_BlazorServer.Services
{
    public class ResultTextService
    {
        private readonly IConfiguration _config;
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

        public ResultTextService(IConfiguration config)
        {
            _config = config;
        }

        public string GetLongText(int number)
        {
            return _config[$"LongText:{number}"];
        }
    }
}
