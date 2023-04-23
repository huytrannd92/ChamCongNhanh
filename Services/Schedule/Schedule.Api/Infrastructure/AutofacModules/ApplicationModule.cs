using Autofac;
using Schedule.Api.Application.Queries;

namespace Schedule.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new CalendarQueries(QueriesConnectionString))
                .As<ICalendarQueries>()
                .InstancePerLifetimeScope();

        }
    }
}
