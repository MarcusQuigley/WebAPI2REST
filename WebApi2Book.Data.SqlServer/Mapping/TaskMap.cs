using FluentNHibernate.Mapping;
using WebApi2Book.Data.DataEntities;
//using System.Threading.Tasks;

namespace WebApi2Book.Data.SqlServer.Mapping
{
    public class TaskMap : VersionedClassMap<Task>
    {
        public TaskMap()
        {
            this.Id(x => x.TaskId);
            this.Map(x=>x.Subject).Not.Nullable();
             this.Map(x=>x.StartDate).Nullable();
             this.Map(x=>x.DueDate).Nullable();
             this.Map(x=>x.CompletedDate).Nullable();
             this.Map(x=>x.CreatedDate).Not.Nullable();

             this.References(x => x.Status, "StatusId"); //StatusId is a db column
            this.References(x=>x.CreatedBy,"CreatedUserId");

            this.HasManyToMany(x => x.Users)
                //NHibernate will use reflection to access the collection of users via your private _users
                //field—as opposed to the public getter.
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore) 
                .Table("TaskUser")
                .ParentKeyColumn("TaskId")
                .ChildKeyColumn("UserId");
        }
    }
}
