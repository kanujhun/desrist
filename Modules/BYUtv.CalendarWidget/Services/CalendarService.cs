using BYUtv.CalendarWidget.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Projections.Models;
using Orchard.Projections.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BYUtv.CalendarWidget.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IProjectionManager _projectionManager;
        private readonly IOrchardServices _orchardServices;

        public CalendarService(IProjectionManager projectionManager, IOrchardServices orchardServices)
        {
            _projectionManager = projectionManager;
            _orchardServices = orchardServices;
        }

        public List<QueryPart> GetCalendarQueries()
        {
            IEnumerable<QueryPart> queryParts = _orchardServices.ContentManager.Query<QueryPart, QueryPartRecord>("Query").List();

            List<QueryPart> calendarQueries = new List<QueryPart>();

            foreach (QueryPart queryPart in queryParts)
            {
                ContentItem contentItem = _projectionManager.GetContentItems(queryPart.Id).FirstOrDefault();

                int countTitleParts = contentItem.TypeDefinition.Parts.Where(r => r.PartDefinition.Name == "TitlePart").Count();
                int countTimeSpanParts = contentItem.TypeDefinition.Parts.Where(r => r.PartDefinition.Name == "TimeSpanPart").Count();

                if (countTitleParts > 0 && countTimeSpanParts > 0)
                {
                    calendarQueries.Add(queryPart);
                }
            }

            return calendarQueries;
        }

        public List<CalendarEvent> GetCalendarEvents(CalendarWidgetPart part)
        {
            IEnumerable<ContentItem> contentItems = _projectionManager.GetContentItems(part.QueryId);

            List<CalendarEvent> calendarEvents = new List<CalendarEvent>();

            foreach (ContentItem contentItem in contentItems)
            {
                dynamic record = _orchardServices.ContentManager.Get(contentItem.Record.Id);

                CalendarEvent calendarEvent = new CalendarEvent
                {
                    Title = record.TitlePart.Title,
                    Start = record.TimeSpanPart.StartDateTime.DateTime,
                    End = record.TimeSpanPart.EndDateTime.DateTime,
                    Url = String.Format("Admin/Contents/Edit/{0}", record.Id)
                };

                calendarEvents.Add(calendarEvent);
            }

            return calendarEvents;
        }
    }
}