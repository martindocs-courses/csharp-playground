/*
    * Mechanism to reuse code and establish a hierarchy (a general-to-specific "is-a" relationship)
    * Code reuse, sharing fields and methods
    * Can have method implementations
    * Can be instantiated
    * Use when you have shared behavior/data to reuse 
 */

using project1 = OOP_Inheritance.Digital_Clock;
using project2 = OOP_Inheritance.Sensor_System;
using project3 = OOP_Inheritance.Vehicle.Maintenance.Log;

// PROJECT 1
//var clock = new project1.Clock();
//clock.GetTime();

//project1.Validator validator = new project1.Validator();
//var alarmClock = new project1.AlarmClock(validator);
//alarmClock.SetAlarm();
//Console.WriteLine(alarmClock.AlarmTime);

// PROJECT 2
//var sensor = new project2.TemperatureSensor();
//sensor.AddTemperature("C");

// PROJECT 3
var project3 = new project3.ElectricVehicle();
project3.MaintenanceLog(milage: 6000,serviceDate: new DateTime(2025, 08, 06),batteryHealth: 86);
