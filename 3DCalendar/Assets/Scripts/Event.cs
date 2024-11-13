using System;

public class Event {
    public string eventType { get; private set; }
    public DateTime _startTime { get; private set; }
    public DateTime _endTime { get; private set; }
    public string location { get; private set; }
    public string description { get; private set; }

    public Event(string eventType, DateTime _startTime, DateTime _endTime, string location, string description) {
        this.eventType = eventType;
        this._startTime = _startTime;
        this._endTime = _endTime;
        this.location = location;
        this.description = description;
    }
}
