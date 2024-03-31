# Adventurer Journey - Back End
Please complete the story below and create a program to solve the problem. Commit any work back to the remote no later than 48 hours before the next interview.

*Please use whatever languages, references and tooling you would like to complete the story.*

## Story Instructions
You are an adventurer standing in the center of a map facing North, and you’re trying to weave through the terrain to your final destination. You have the directions to your destination indicating the number of steps and the direction to travel.

Adventurer Path & Instructions - [./Adventurer Path.md](./Adventurer%20Path.md)

Given the Path Instructions above, programmatically parse the instructions and determine what is the Euclidean (straight line) distance from your starting point to the destination in steps?

**Tech Notes:**
- Use whatever languages, references and tooling you would like.
- Provide any needed instructions to run program.
- Do not round to the nearest step.
- After program executes the answer should be returned.



---------------------------------------------------------------------------------------------------
Adventurer Journey Solution README.md
-------------------------------------

I decided to complete the solution using C#. I provided a .NET project solution in the 
AdventurerJourney directory, and a Polyglot Notebooks solution in AdveturerJourney.ipynb.  
These solutions work identically with nearly identical source code. The .ipynb file provides 
documentation within explaining the code, the .NET project solution documentation will be included 
in this README.md and comments describing the code will be included.

Polyglot Notebook
-----------------
The best way to view the notebook is by using using the Polyglot Notebook extension in VSCode.
Make sure .NET 8.0 SDK is installed and grab the Polyglot Notebook extension from the VSCode 
extension marketplace.

Otherwise, this .ipynb file is viewable from any notebook environment(e.g. Google Colab 
or Jupyter Notebook). It won't be executable, but all the code and outputs are saved for viewing.

To run the notebook use the 'Run All' button at the top of the notebook editor or run the code
cells in order.

.NET Console App
----------------
To create the .NET Console App version, I used the C# Dev Kit extension in VSCode.

In order to run the project, make sure .NET Desktop runtime is installed. If using VSCode the
.NET Install Tool extension can be used - open the command palette and use .NET Install tool to install
SDK version 8.0.XX.

To run the project navigate to the AdventurerJourney project directory and in terminal run 'dotnet run'.