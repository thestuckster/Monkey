Monkey
===

Monkey is an interpreter / language implemented from following the book [Writing an Interpreter in Go](https://interpreterbook.com/),
I chose to use C# instead. 

## How To Run
You can easily run the REPL with the command
```bash
dotnet run --project Monkey
```

## How To Build
You can build the monkey project by running the command
```bash
dotnet build --configuration Release 
```

Which will generate an output that you can run with:
```bash
./Monkey/bin/Release/net6.0/Monkey 
```

## How To Test
You can find some small sample programs in the `Monkey.Test/Programs` folder. These files are set to copy on build.
You can run the command
```bash
dotnet test
```

to run all the available unit tests. These unit tests will read the programs from the `Monkey.Test/Programs` directory mentioned above


## FAQ

**Q**: Why use C# when the book was written in Go? 

**A**: I like C# and I haven't done many side projects in it yet, even though I write it every day at work there are still parts of the language I don't get to touch every day.
Also there's no better way to make sure you understand languages than by translating them from each other. Its been a fun challenge


**Q**: What do you hope to get out of this?

**A**: `/shrug` entertainment and something to talk about 

**Q**: Why not use bison, or yacc, or any other parser alternative to do the hard part for you?

**A**: That wouldn't be much of a learning experience now would it? But after writing even a basic parser I know understand why people rely on those tools