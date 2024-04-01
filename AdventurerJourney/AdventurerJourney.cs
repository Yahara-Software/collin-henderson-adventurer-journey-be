
/*string directions: will be a string of numbers combined with either F, B, R, or L 
that describes the path to the destination, parsed from 'Adventurer Path.md' file.*/

/*int x, int y: will be the destination of the adventurer, to be used in finding the 
euclidean distance*/

string directions = string.Empty;
int x = 0, y = 0;

/*first try block reads directions from 'Adventurer Path.md'. Throws exception if file
is not found or no directions are found*/
try
{
    StreamReader sr = new StreamReader(@"../Adventurer Path.md");
    string? line = sr.ReadLine();
    /*This loop will read every line in the file until it finds a line that starts with a backtick(`).
    This line will be used as the instruction set - ONLY this line will count towards directions, there
    cannot be multiple direction lines.*/
    while (line != null)
    {
        /*check lenght to avoid index out of bounds on empty lines*/
        if(line.Length == 0)
        {
            line = sr.ReadLine();
            continue;
        }
        if(line[0] == '`')
        {
            directions = line.Trim('`');
            break;
        }
        line = sr.ReadLine();
    }
    sr.Close();

    if(string.IsNullOrEmpty(directions))
    {
        throw new ArgumentNullException("There were no instructions found in the file! Make sure a line of an instruction set surrounded by `backticks` exists in 'Adveturer Path.md'.");
    }
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
    System.Environment.Exit(1);
}

/*this try block takes the directions and computes the destination coordinates on an x and y axis,
throws an exception if the direction set in invalid.*/
try{
    /*string numberOfSteps: will be used to keep track of the amount of steps for each direction*/
    string numberOfSteps = string.Empty;
    /*This loops parses the directions to find the destination. Integers will be counted towards number
    of steps until a direction F, B, R, or L is found. Then the number of steps will be counted to the
    x or y axis respectively, and number of steps will be reset to 0.*/
    for(int i = 0; i < directions.Length; i++)
    {
        if(char.IsDigit(directions, i))
        {
            numberOfSteps += directions[i];
        }
        else
        {
            int steps;
            /*Throws an exception if numberOfSteps is not an integer. This happens when numberOfSteps is an empty string
            because of a direction without an associated integer before it, making it invalid.*/
            if(!Int32.TryParse(numberOfSteps, out steps))
            {
                throw new ArgumentException("Int32.TryParse failed to parse the steps. Make sure each direction has an integer for amount of steps directly before.");
            }
            /*Upon reaching a direction, the current numberOfSteps is added to the x/y axis of the destination.*/
            if(directions[i] == 'F')
            {
                y += steps;
            }
            else if(directions[i] == 'B')
            {
                y -= steps;
            }
            else if(directions[i] == 'R')
            {
                x += steps;
            }
            else if(directions[i] == 'L')
            {
                x -= steps;
            }
            else{
                /*If there is a bad char in the directions this exception will be thrown.*/
                throw new ArgumentException($"{directions[i]} is not a valid direction! Please use directions F, B, L, and R.");
            }
            numberOfSteps = string.Empty;
        }
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
    System.Environment.Exit(1);
}

/*finally, compute the euclidean distance using the destination x and y coordinates and 
print the output.*/
try
{
    x = Math.Abs(x);
    y = Math.Abs(y);
    double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    Console.WriteLine(distance);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
    System.Environment.Exit(1);
}