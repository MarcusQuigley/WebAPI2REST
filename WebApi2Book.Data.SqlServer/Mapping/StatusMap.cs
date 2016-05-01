using WebApi2Book.Data.DataEntities;

namespace WebApi2Book.Data.SqlServer.Mapping
{
    public class StatusMap : VersionedClassMap<Status>
    {
        public StatusMap()
        {
            this.Id(x => x.StatusId);
            this.Map(x => x.Name).Not.Nullable();
            this.Map(x => x.Ordinal).Not.Nullable();
        }
    }
}
