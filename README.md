1. Code Line Coverage
Measures the % of the lines of code in a program that have been executed by a set of test cases.
The simplest type of code cov. and its often used as a baseline for measuring the effectiveness of the other types of code coverage.

Example: This code has four lines, to achieve 100% line coverage all four lines of code must be exeucted by a set of test cases.
x = 10;
y = 20;
z = x + y;
print(z);

2. Statement Coverage
Ensures that every executable statement in the code has been run at least once.
Concerned with executing all the lines of code that perform an action or operation.

Example: The executable statement is Console.WriteLine("Hey!");
To achieve 100% statement coverage, one test where both condition and condition2 are true, so that the statement is executed.
if (condition)
{
	if (condition2)
	{
		Console.WriteLine("Hey!");
	}
};

3. Branch Coverage
Branch coverage goes a step further by ensuring that each possible branch is executed.
A "branch" is one of the possible execution paths the code can take after a decision statement.

Example: 100% branch coverage, 3 tests:
condition = true;
condition2 = true;

condition = true;
condition2 = false;

condition = false;

if (condition){
	if (condition2){
		Console.WriteLine("Hey!");
	}
}

4. Function Coverage
Measures the functions invoked during testing.
It simply determines whether each function was called by the tests you were running

Example: 100% function coverage, one test is required.
The greet() function has only one entry point and all of its code is executed within the function.

public void greet(bool condition, bool condition2)
{
	if (condition && condition2)
	{
		Console.WriteLine("Hey!");
	}
}

5. Condition Coverage
Focused on evaluating all the Boolean expressions in the decision paths.
It ensures that every condition in a decision statement like IF is tested for both true and false values.

Example: 100% condition coverage, 4 tests: 1) both condition = true;
										   2) condition = true;
											  condition2 = false;
										   3) condition = false;
											  condition2 = true;
										   4) both conditions = false;
										   
public void greet(bool condition, bool condition2)
{
	if (condtion && condition2)
	{
		Console.WriteLine("Hey!");
	}
}

6. Path Coverage
Ensuring every possible route through a given part of the code is executed.
Collects info about in which order the consecutive statements are executed, the branches that are examined and how logical conditions evaluated.
This can be more comprehensive but also more complex, as the number of paths can grow exponentially with more complex code.

Example: 100% path coverage, 4 tests:      1) both condition = true; and "Hey!" is printed;
										   2) condition = true; 
											  condition2 = false; and code does nothing;
										   3) condition = false;
											  condition2 = true; and code does nothing;
										   4) both conditions = false; and code does nothing;
										   
public void greet(bool condition, bool condition2)
{
	if (condition && condition2)
	{
		Console.WriteLine("Hey!");
	}
}

Types of code coverage conclusion:
1) Line - % of lines of code that have been executed
2) Statement - % of executable statements
3) Branch - % of branches(decision points) in the code. This includes both conditional(if-else statements) and unconditional(break, continue, return statements)
4) Function - % of fucntions or methods in the code that have been called
5) Condition - % of conditions in the code that have been evaluated to both true and false at least once
6) Path - % of all possible paths through the code

Tools to explore for code coverage in C#:

1) Coverlet.collector - is a NuGet package used to collect code coverage data from .NET applications;
Compatible with Windows, macOS and Linux
Comes pre-installed with new NUnit projects in VS
Simple and easy-to-use tool
https://github.com/coverlet-coverage/coverlet

2) Report Generator is an extension that given the code coverage report displays the result in a human-readable format
To install it open the PowerShell with admin privs. and run the following commands:
dotnet tool install -g dotnet-reportgenerator-globaltool
dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools
dotnet new tool-manifest
dotnet tool install dotnet-reportgenerator-globaltool
These commands install ReportGenerator alongside global .NET tools

3) Fine Code Coverage is a free extension for VS.
Provides a visual representation of code coverage highlighting which parts of the code have been tested and which parts have not.
