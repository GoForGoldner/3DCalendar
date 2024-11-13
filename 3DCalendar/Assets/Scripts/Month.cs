using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month {
    public int MonthNumber { get; private set; }
    private readonly int _daysInMonth;
    public List<Day> Days { get; private set; }

    public Month(int month, int year) {
        MonthNumber = month;
        _daysInMonth = DateTime.DaysInMonth(year, month);

        Days = new List<Day>(_daysInMonth);
        for (int i = 0; i < _daysInMonth; i++) {
            Days.Add(new Day(i + 1));
        }
    }
}
