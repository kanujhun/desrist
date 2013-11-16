/// <reference path="ext/jQuery/jquery.d.ts" />
/// <reference path="ext/fullcalendar/IFullCalendar.ts" />
/// <reference path="Event.ts" />
var BYUtv;
(function (BYUtv) {
    var CalendarWidget = (function () {
        function CalendarWidget(Id, Events) {
            var fullCalEvents = [];
            var iterator = function (event) {
                var newEvent;
                newEvent = new BYUtv.Event(event.title, event.start, event.end, event.url, false);
                fullCalEvents.push(newEvent);
            };
            Events.forEach(iterator);
            $('#' + Id).fullCalendar({
                theme: true,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                editable: false,
                ignoreTimezone: false,
                events: fullCalEvents
            });
        }
        return CalendarWidget;
    })();
    BYUtv.CalendarWidget = CalendarWidget;    
})(BYUtv || (BYUtv = {}));
//@ sourceMappingURL=CalendarWidget.js.map
