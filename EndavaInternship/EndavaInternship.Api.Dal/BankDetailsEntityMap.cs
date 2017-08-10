using FluentNHibernate.Mapping;

namespace EndavaInternship.Api.Dal
{
    public class BankDetailsEntityMap : ClassMap<BankDetailsEntity>
    {
        public BankDetailsEntityMap()
        {
            Id(x => x.UserId).GeneratedBy.Assigned();
            Map(x => x.FullName);
            Map(x => x.CardNumber);
            Map(x => x.SecurityCode);
        }
    }
}