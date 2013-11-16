using BYUtv.CalendarWidget.Models;
using BYUtv.CalendarWidget.Services;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;

namespace BYUtv.CalendarWidget.Drivers
{
    /*
     * Driver
     * Drivers are similar to MVC controllers, but they act at the level of a content part instead of at the level of the full request.
     * They typically prepare shapes for rendering and handle post-backs from admin editors.
     */
    public class CalendarWidgetDriver : ContentPartDriver<CalendarWidgetPart>
    {
        private readonly IOrchardServices _orchardServices;
        private readonly ICalendarService _calendarService; // a custom service that we use to retrieve data and create objects

        public Localizer T { get; set; } // handles string localization

        /*
         * IDependency
         * Services should implement IDependency, if they do:
         * the application framework will discover all dependencies and will take care of instantiating and injecting instances as needed.
         */
        public CalendarWidgetDriver(IOrchardServices orchardServices, ICalendarService calendarService)
        {
            _orchardServices = orchardServices;
            _calendarService = calendarService;

            T = NullLocalizer.Instance;
        }

        // GET - Render Shape
        protected override DriverResult Display(CalendarWidgetPart part, string displayType, dynamic shapeHelper)
        {
            /*
             * Shape
             * A very malleable object (dynamic data model) that contains all the information required in order to dispaly its data.
             * All data needs to be transformed into a shape (a blob of data) before it can be rendered in a template.
             * The template is aware of all the shapes (tree of shapes) that it needs to render.
             * Modules can create or modify (new or existing) shapes.
             * http://docs.orchardproject.net/Documentation/Accessing-and-rendering-shapes
             */
            return ContentShape("Parts_CalendarWidget", // Shape type names the shape and binds it to a template, by convention, all part shapes begin with Parts_ followed by the name of the part.  Orchard uses this convention to lookup the view to use (Views/Parts/CalendarWidget.cshtml).  Do not forget to add a node in Placement.info for this shape.
                () => shapeHelper.Parts_CalendarWidget( // function expression, the Dispaly method uses a pattern of shapeHelper.Parts_Name
                    CalendarEvents: _calendarService.GetCalendarEvents(part) // objects that will be available in the view as part of the dynamic model (in CalendarWidget.cshtml @Model.CalendarItems)
                )
            );
        }

        // GET - Render Shape
        protected override DriverResult Editor(CalendarWidgetPart part, dynamic shapeHelper)
        {
            // Creating a model, or view-model, in this way will allow us to pass additional data to the view that is not contained in CalendarWidgetPart.
            var model = new CalendarWidgetPartQueries
            {
                Queries = _calendarService.GetCalendarQueries(),
                QueryId = part.QueryId
            };

            return ContentShape("Parts_CalendarWidget_Edit",
                () => shapeHelper.EditorTemplate( // shapeHelper.EditorTemplate is a special shape that has a TemplateName and Model property, use this shape when creating admin editor views.
                    TemplateName: "Parts/CalendarWidget", // searches within Views/EditorTemplates for the template named CalendarWidget.cshtml (Views/EditorTemplates/Parts/CalendarWidget.cshtml).
                    Model: model, // type CalendarWidgetPartQueries
                    Prefix: Prefix
                )
            );
        }

        // POST - Post-back from admin editor
        protected override DriverResult Editor(CalendarWidgetPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, new string[] { "Queries" }); // populates part with the data returned by the view.  The view recieved Queries via the view-model CalendarWidgetPartQueries but we are only concerned with those attributes that are in CalendarWidgetPart

            // logic to test if we have the correct values to store in the database
            if (part.QueryId <= 0)
            {
                updater.AddModelError("QueryId", T("You must select a query.")); // model error with localization
            }

            return Editor(part, shapeHelper);
        }
    }
}