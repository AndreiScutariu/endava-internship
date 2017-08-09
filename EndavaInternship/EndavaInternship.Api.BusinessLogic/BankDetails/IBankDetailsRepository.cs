namespace EndavaInternship.Api.BusinessLogic.BankDetails
{
    public interface IBankDetailsRepository
    {
        void Save(string userId, BankDetails bankDetails);

        BankDetails Get(string userId);
    }
}