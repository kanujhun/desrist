using BYUtv.CalendarWidget.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

// http://docs.orchardproject.net/Documentation/Understanding-content-handlers
namespace BYUtv.CalendarWidget.Handlers
{
    /*
     * Handler
     * Handlers are similar to an MVC filter in that they contain code that will execute for specific events of the request life-cycle.
     * They are typically used to set-up data repositories or to do additional operations when something gets loaded.
     */
    public class CalendarWidgetHandler : ContentHandler
    {
        public CalendarWidgetHandler(IRepository<CalendarWidgetPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository)); // takes care of persisting the data from the repository object to the database
        }
    }
}