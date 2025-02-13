/*
     Student Grading application that automates the calculation of grades for each student in a class 
*/

// grade assigments
int currentAssignments = 5;

string[] students = ["Sophia", "Andrew", "Emma", "Logan"];

int[] sophiaScores = [90, 86, 87, 98, 100];
int[] andrewScores = [92, 89, 81, 96, 90];
int[] emmaScores = [90, 85, 87, 98, 68];
int[] loganScores = [90, 95, 87, 88, 96];

// extra students scores
int[] sophiaExtraCreditScore = new int[] { 94, 90 };
int[] andrewExtraCreditScore = new int[] { 89 };
int[] emmaExtraCreditScore = new int[] { 89, 89, 89 };
int[] loganExtraCreditScore = new int[] { 96 };

// report header
Console.WriteLine("Student\t\tGrade\n");

foreach (string currentStudentName in students)
{
    int[] studentsScores = [];

    if (currentStudentName.ToLower() == "sophia")
    {
        studentsScores = sophiaScores.Concat(sophiaExtraCreditScore).ToArray();

    }
    else if (currentStudentName.ToLower() == "andrew")
    {
        studentsScores = andrewScores.Concat(andrewExtraCreditScore).ToArray();

    }
    else if (currentStudentName.ToLower() == "emma")
    {
        studentsScores = emmaScores.Concat(emmaExtraCreditScore).ToArray();
    }
    else if (currentStudentName.ToLower() == "logan")
    {
        studentsScores = loganScores.Concat(loganExtraCreditScore).ToArray();
    }


    if (studentsScores.Length > 0)
    {
        int totalAssigmentScore = 0;
        int gradedAssigments = 0;

        foreach (int score in studentsScores)
        {
            gradedAssigments += 1;

            if (gradedAssigments <= currentAssignments)
            {
                totalAssigmentScore += score;
            }
            else
            {
                // add 10% of extra credit points to the total
                totalAssigmentScore += score / 10;
            }
        }

        decimal currentStudentGrade = (decimal)totalAssigmentScore / currentAssignments;

        string currentLetterGrade;

        if (currentStudentGrade >= 97)
        {
            currentLetterGrade = "A+";
        }
        else if (currentStudentGrade >= 93)
        {
            currentLetterGrade = "A";
        }
        else if (currentStudentGrade >= 90)
        {
            currentLetterGrade = "A-";
        }
        else if (currentStudentGrade >= 87)
        {
            currentLetterGrade = "B+";
        }
        else if (currentStudentGrade >= 83)
        {
            currentLetterGrade = "B";
        }
        else if (currentStudentGrade >= 80)
        {
            currentLetterGrade = "B-";
        }
        else if (currentStudentGrade >= 77)
        {
            currentLetterGrade = "C+";
        }
        else if (currentStudentGrade >= 73)
        {
            currentLetterGrade = "C";
        }
        else if (currentStudentGrade >= 70)
        {
            currentLetterGrade = "C-";
        }
        else if (currentStudentGrade >= 67)
        {
            currentLetterGrade = "D+";
        }
        else if (currentStudentGrade >= 63)
        {
            currentLetterGrade = "D";
        }
        else if (currentStudentGrade >= 60)
        {
            currentLetterGrade = "D-";
        }
        else
        {
            currentLetterGrade = "F";
        }

        Console.WriteLine($"{currentStudentName}:\t\t{currentStudentGrade}\t{currentLetterGrade}");
    }
}

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();


