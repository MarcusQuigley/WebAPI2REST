using FluentNHibernate.Mapping;
using WebApi2Book.Data.DataEntities;

namespace WebApi2Book.Data.SqlServer.Mapping
{
   public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedEntity
    {
       protected VersionedClassMap()
       {
           Version(x => x.Version)
               .Column("ts") //db column
               .CustomSqlType("Rowversion")
               .Generated.Always() //let db create value
               .UnsavedValue("null");  
       }
    }
}
