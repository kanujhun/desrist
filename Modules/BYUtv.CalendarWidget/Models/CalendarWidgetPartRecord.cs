using Orchard.ContentManagement.Records;

// http://docs.orchardproject.net/Documentation/Writing-a-content-part
namespace BYUtv.CalendarWidget.Models
{
    /*
     * Record
     * A record is a class that models the database representation of a content part.
     * Records are POCOs where each property must be virtual.  http://msdn.microsoft.com/en-us/library/vstudio/dd456853(v=vs.100).aspx
     */
    /* ContentPart Class and ContentPartRecord Class
     * In Orchard, content part data is represented by a Record class, which represents the fields that are stored to a database table, and a ContentPart class that uses the Record for storage.
     */
    public class CalendarWidgetPartRecord : ContentPartRecord
    {
        public virtual int QueryId { get; set; }
    }
}