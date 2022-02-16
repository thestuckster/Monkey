// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;
using Monkey;

const string prompt = ">> ";

Console.WriteLine("Welcome to the MREPL - Monkey Read Eval Print Loop");
Console.Write(prompt);

string line;
while ((line = Console.ReadLine()) is not "" or null)
{
    Console.Write(prompt);
    if (line is "exit" or null) return;

    var lexer = new Lexer(line);
    while (lexer.HasNextToken())
    {
        Console.WriteLine(lexer.NextToken().ToString());
    }
}