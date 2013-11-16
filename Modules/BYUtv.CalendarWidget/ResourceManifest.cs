using Orchard.UI.Resources;

namespace BYUtv.CalendarWidget
{
    public class ResourceManifest : IResourceManifestProvider
    {
        /*
         * Resource Manifest
         * The ResourceManifest file defines the names of resources (a script or css file), the location of that resource, including the debug version, and the resource dependencies.  You can optionally define attributes of the resource.
         */
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineScript("FullCalendar").SetUrl("ext/fullcalendar/fullcalendar.min.js", "ext/fullcalendar/fullcalendar.js").SetDependencies("jQuery", "jQueryUI");
            manifest.DefineScript("Event").SetUrl("Event.min.js", "Event.js");
            manifest.DefineScript("CalendarWidget").SetUrl("CalendarWidget.min.js", "CalendarWidget.js").SetDependencies("FullCalendar", "Event");

            manifest.DefineStyle("FullCalendarPrint").SetUrl("ext/fullcalendar/fullcalendar.print.css").SetAttribute("media", "print").SetDependencies("jQueryUI_Orchard");
            manifest.DefineStyle("FullCalendar").SetUrl("ext/fullcalendar/fullcalendar.css").SetDependencies("jQueryUI_Orchard");
            manifest.DefineStyle("CalendarWidget").SetUrl("CalendarWidget.min.css", "CalendarWidget.css").SetDependencies("FullCalendar", "FullCalendarPrint", "jQueryUI_Orchard");

            // These resources can now be used in views as follows (assumes Razor engine):
            // @Sytle.Require("CalendarWidget");
            // @Script.Require("calendarWidget");

            // Styles are injected into the head and scripts are injected into the bottom of the body.
        }
    }
}