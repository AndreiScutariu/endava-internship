namespace EndavaInternship.Api.Contracts
{
    public class CreateUserBankDetailsRequest
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public string CardNumber { get; set; }

        public string SecurityCode { get; set; }
    }
}