using Orchard.Projections.Models;
using System.Collections.Generic;

namespace BYUtv.CalendarWidget.Models
{
    public class CalendarWidgetPartQueries
    {
        public IEnumerable<QueryPart> Queries { get; set; }
        public int QueryId { get; set; }
    }
}