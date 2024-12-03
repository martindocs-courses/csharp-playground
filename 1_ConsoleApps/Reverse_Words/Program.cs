// SOLUTION 1
Console.WriteLine("Solution 1");
string panagramSolution1 = "The quick brown fox jumps over the lazy dog";

string[] splitArraySolution1 = panagramSolution1.Split(" ");

string result = "";
foreach (string word in splitArraySolution1)
{
    char[] eachWord = word.ToCharArray();
    Array.Reverse(eachWord);
    string reversedWordSolution1 = string.Join("", eachWord);
    result += reversedWordSolution1 + " ";
}

Console.WriteLine(result.Trim());


// SOLUTION 2
Console.WriteLine("\nSolution 2");
string panagramSolution2 = "The quick brown fox jumps over the lazy dog";

string[] splitArraySolution2 = panagramSolution2.Split(" ");
string[] newSentenceSolution2 = new string[splitArraySolution2.Length];

for (int i = 0; i < splitArraySolution2.Length; i++)
{
    char[] eachWord = splitArraySolution2[i].ToCharArray();
    Array.Reverse(eachWord);
    newSentenceSolution2[i] = new string(eachWord);
}

string reversedWordSolution2 = string.Join(" ", newSentenceSolution2);
Console.WriteLine(reversedWordSolution2);