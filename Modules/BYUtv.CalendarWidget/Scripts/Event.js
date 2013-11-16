/// <reference path="IEvent.ts" />
var BYUtv;
(function (BYUtv) {
    var Event = (function () {
        function Event(title, start, end, url, allDay) {
            this.title = title;
            this.start = start;
            this.end = end;
            this.url = url;
            this.allDay = allDay;
        }
        return Event;
    })();
    BYUtv.Event = Event;    
})(BYUtv || (BYUtv = {}));
//@ sourceMappingURL=Event.js.map
