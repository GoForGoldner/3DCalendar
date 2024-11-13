using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Year {
    public int YearNumber { get; private set; }
    public List<Month> Months { get; private set; } = new List<Month>(12);

    public Year(int year) {
        YearNumber = year;
        for (int i = 0; i < 12; i++) {
            Months.Add(new Month(i + 1, year));
        }
    }
}
