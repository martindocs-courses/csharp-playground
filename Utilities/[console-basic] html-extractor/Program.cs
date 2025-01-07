/*
    you work with a string that contains a fragment of HTML. You extract data from the HTML fragment, replace some of its content, and remove other parts of its content to achieve the desired output.
*/

const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

// VERSION 1
//int quantityPosition = input.IndexOf("5000");
//quantity = input.Substring(quantityPosition, 4);
//output = input.Remove(0, 5).Remove(41).Replace("trade", "reg");

// VERSION 2
const string openDiv = "<div>";
const string closeDiv = "</div>";
const int shiftDivPos = 5;
const string tradeSymbol = "&trade;";
const string regSymbol = "&reg;";
output = input;

while (true)
{
    int startPos = output.IndexOf(openDiv);

    if (startPos == -1)
    {
        output = output.Replace(tradeSymbol, regSymbol);
        break;
    }

    startPos += shiftDivPos;

    int closePos = output.IndexOf(closeDiv, startPos);

    output = output.Substring(startPos, closePos - startPos);
};
const string numberInText = "5000";
int quantityPosition = input.IndexOf(numberInText);
quantity = input.Substring(quantityPosition, numberInText.Length);

Console.WriteLine($"Quantity: {quantity}");
Console.WriteLine($"Output: {output}");
