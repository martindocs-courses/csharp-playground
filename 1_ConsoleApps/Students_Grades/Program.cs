/* Student Grading application that automates the calculation of current grades for each student in a class.  */

int currentAssigment = 5;

int sophiaAssigmentsScores = 93 + 87 + 98 + 95 + 100;
int nicolasAssigmentsScores = 80 + 83 + 82 + 88 + 85;
int zahirahAssigmentsScores = 84 + 96 + 73 + 85 + 79;
int jeongAssigmentsScores = 90 + 92 + 98 + 100 + 97;

// Sophia Score
decimal sophiaAvgScore = 
    (decimal) sophiaAssigmentsScores / (decimal) currentAssigment;

// Nocola Score
decimal nicolasAvgScore = 
    (decimal) nicolasAssigmentsScores / (decimal)currentAssigment;

// Zahirah Score
decimal zahirahAvgScore = 
    (decimal) zahirahAssigmentsScores / (decimal)currentAssigment;

// Sophia Score
decimal jeongAvgScore = 
    (decimal) jeongAssigmentsScores / (decimal)currentAssigment;

// Students grades
Console.WriteLine($"Student\t\tGrade");
Console.WriteLine($"Sophia\t\t{sophiaAvgScore}\tA");
Console.WriteLine($"Nicolas\t\t{nicolasAvgScore}\tB");
Console.WriteLine($"Zahirah\t\t{zahirahAvgScore}\tB");
Console.WriteLine($"Jeong\t\t{jeongAvgScore}\tA");