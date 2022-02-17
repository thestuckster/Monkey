// See https://aka.ms/new-console-template for more information

using Monkey;

const string prompt = ">> ";

Console.WriteLine("Welcome to the MREPL - Monkey Read Eval Print Loop");
while (true)
{
    Console.Write(prompt);
    var line = Console.ReadLine();

    if (line is null or "") return;
    if (line is "exit" or "quit") return;

    var lexer = new Lexer(line);
    while(lexer.HasNextToken()) Console.WriteLine(lexer.NextToken().ToString());
}