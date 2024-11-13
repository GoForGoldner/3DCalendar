using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class Model : MonoBehaviour {
    private const int _startingYear = 2010;
    private const int _numberOfYears = 20;

    private List<Year> _years = new(_numberOfYears);
    

    public void Start() {
        // Import the data from the CSV file
        for (int i = 0; i < _numberOfYears; i++) {
            _years.Add(new Year(i + _startingYear));
        }

        ImportFile("Assets/CalendarFiles/CalendarExample1.csv");

        //printCalendar();
    }

    public void AddEvent(Event newEvent) {
        _years[newEvent._startTime.Year - _startingYear]
            .Months[newEvent._startTime.Month]
            .Days[newEvent._startTime.Day]
            .Events.Add(newEvent);
    }

    public void ImportFile(string fileName) {
        if (!File.Exists(fileName)) {
            Debug.Log("File not found :(\n");
            return;
        }

        using StreamReader streamReader = new(File.OpenRead(fileName));
        while (!streamReader.EndOfStream) {
            string line = streamReader.ReadLine();
            string[] values = line.Split(',');

            try {
                // Create a new Event object with parsed DateTime
                Event newEvent = new(
                    values[0],
                    DateTime.Parse(values[1]), // Use Parse to convert string to DateTime
                    DateTime.Parse(values[2]),
                    values[3],
                    values[4]
                );

                Debug.Log
                    ($"Event added: Type = {newEvent.eventType}," +
                    $" Start = {newEvent._startTime}," +
                    $" End = {newEvent._endTime}," +
                    $" Location = {newEvent.location}," +
                    $" Description = {newEvent.description}");

                AddEvent(newEvent);
            }
            catch (FormatException ex) {
                Debug.Log($"Date format error in line: {line}. Error: {ex.Message}");
            }
        }
    }

    void printCalendar() {
       foreach (Year year in _years) {
            print($"Year: {year.YearNumber}\n");
            foreach (Month month in year.Months) {
                //print($"Month: {month.MonthNumber}\n");
                foreach (Day day in month.Days) {
                    foreach (Event e in day.Events) {
                        print($"{e._startTime} - {e._endTime}\n");
                    }
                }
            }
       }
    }
}
