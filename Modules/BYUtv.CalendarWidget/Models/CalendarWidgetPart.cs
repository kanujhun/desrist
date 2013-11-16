using Orchard.ContentManagement;

// http://docs.orchardproject.net/Documentation/Writing-a-content-part
namespace BYUtv.CalendarWidget.Models
{
    /*
     * Model
     * The part calss itself plays the part of the model for a content part.
     * Some parts also define view-models, in the form of stringly-typed classes or more flexible dynamic shapes.
     */
    /* ContentPart Class and ContentPartRecord Class
     * In Orchard, content part data is represented by a Record class, which represents the fields that are stored to a database table, and a ContentPart class that uses the Record for storage.
     */
    public class CalendarWidgetPart : ContentPart<CalendarWidgetPartRecord>
    {
        public int QueryId
        {
            get { return Record.QueryId; }
            set { Record.QueryId = value; }
        }
    }
}