using SACCO_MANAGEMENT.Data.LoanInterfaces;

namespace SACCO_MANAGEMENT.Models.InterestRates
{
    public class InterestRates
    {
        Guid Id { get; set; }
        string Name { get; set; }
        double Rate { get; set; }
        RateType Type { get; set; }
    }
}
