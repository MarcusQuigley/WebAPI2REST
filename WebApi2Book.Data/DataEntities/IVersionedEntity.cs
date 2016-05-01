
namespace WebApi2Book.Data.DataEntities
{
   public interface IVersionedEntity
    {
       byte[] Version { get; set; }
    }
}
