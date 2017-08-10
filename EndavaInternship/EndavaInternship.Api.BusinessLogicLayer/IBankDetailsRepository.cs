namespace EndavaInternship.Api.BusinessLogicLayer
{
    public interface IBankDetailsRepository
    {
        void Save(string userId, BankDetails bankDetails);
        BankDetails Get(string userId);
    }
}