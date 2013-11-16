using BYUtv.CalendarWidget.Models;
using Orchard;
using Orchard.Projections.Models;
using System.Collections.Generic;

// http://msdn.microsoft.com/en-us/magazine/hh708754.aspx (see section on Dependency Injection)
namespace BYUtv.CalendarWidget.Services
{
    /*
     * IDependency
     * Any module can provide its own extensibility points by just declaring an interface that derives from IDependency.
     * 
     * A key way to reach the goal of non-hard dependencies is to use dependency injection.
     * When you need to use the services from another class, you do not just instantiate the class, as that would establish a hard-dependency on that class.
     * Instead, you inject an interface that this class implements, as a constructor parameter.
     */
    public interface ICalendarService : IDependency
    {
        List<CalendarEvent> GetCalendarEvents(CalendarWidgetPart part);
        List<QueryPart> GetCalendarQueries();
    }
}