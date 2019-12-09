namespace Raci.B2C.Bicycle.Service.DTO
{
    public class PolicyDTO
    {
        public string PolicyNumber { get; set; }
        public long Id { get; set; }
        public bool IsNew { get; set; }
        public bool IsQuote { get; set; }
        public bool IsPolicy { get; set; }

        public PolicyOptionDTO Option { get; set; }
        public PolicyContactDTO Contact { get; set; }
        public BicyclePolicyDetailDTO Detail { get; set; }
        public PaymentDetailDTO Payment { get; set; }
    }
}