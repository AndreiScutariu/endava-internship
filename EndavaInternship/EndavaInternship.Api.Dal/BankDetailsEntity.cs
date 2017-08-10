namespace EndavaInternship.Api.Dal
{
    public class BankDetailsEntity
    {
        public virtual string UserId { get; set; }

        public virtual string FullName { get; set; }

        public virtual string CardNumber { get; set; }

        public virtual string SecurityCode { get; set; }
    }
}