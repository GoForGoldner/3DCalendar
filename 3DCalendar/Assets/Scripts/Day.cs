using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day {
    public int DayNumber { get; private set; }
    public List<Event> Events { get; private set; } = new List<Event>();

    public Day(int day) {
        DayNumber = day;
    }
}
