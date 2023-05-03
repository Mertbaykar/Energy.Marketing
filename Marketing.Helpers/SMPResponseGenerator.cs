using Marketing.Models;

namespace Marketing.Helpers
{
    public class SMPResponseGenerator
    {
        public static SMPResponse Generate()
        {
            SMPResponse response = new SMPResponse
            {
                Body = new SMPContainer(),
                ResultCode = string.Empty,
                ResultDescription = string.Empty,
            };

            for (int i = 0; i < 2; i++)
            {
                var smp = SMPGenerator.Generate();
                response.Body.SmpList.Add(smp);
            }

            return response;
        }

       
    }

    public class SMPGenerator
    {
        public static SMP Generate()
        {
            return new SMP
            {
                Date = DateTime.Now,
                Price = 10,
                SmpDirectionId = 30,
            };
        }
    }
}