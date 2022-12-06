// See https://aka.ms/new-console-template for more information


using JaneCalc.UI;


Display display = new Display();


Console.WriteLine("Welcome to my calculator,type help to continue or exit to close");
Console.Write(">");
string response = Console.ReadLine().Trim().ToLower();

while (!response.Equals("") && !response.Equals("exit"))
{
    if (response.Equals("help"))
    {
        display.UserGuide();
    }
    else if (response.Equals("next"))
    {
        display.CalculateGPA();
    }
    else if (response.Equals("print"))
    {
        display.PrintResult();
    }
    else
    {
        Console.Write("Enter a valid command, type help to see all options");
    }
    Console.Write(">");
    response = Console.ReadLine().ToLower();
    Console.Clear();
}