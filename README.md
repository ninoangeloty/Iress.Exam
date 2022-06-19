# OVERVIEW
A Toy Robot coding challenge designed using Command pattern.

# HOW TO USE
Open the solution using Visual Studio and Rebuild the application. Run the solution with the Iress.Client set as Startup Project. Enter robot commands through the console application.

Unit tests can be found at Iress.Tests project.

# SOME INFO ABOUT THE CODE

**ServiceCollection** - Simple IoC container for instantiating dependencies

**CommandAggregator** - Route commands to their respective command handlers (ICommandHandler<T, U>)

**RobotCommandHelper** - Helper for creating a command from a user's input

**CacheContext** - Simplified persistence store

# NOTES
The solution is built using .Net Core 3.1. 
