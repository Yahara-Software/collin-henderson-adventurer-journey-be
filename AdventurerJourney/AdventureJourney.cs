
/*String directions: will be a string of numbers combined with either F, B, R, or L 
that describes the path to the destination, parsed from 'Adventurer Path.md' file.*/

/*int x, int y: will be the destination of the adventurer, to be used in finding the 
euclidean distance*/

/*directionsInvalid: checks if directions parsing succeeded, throws exception in the
third try block if parsing failed*/

String directions = string.Empty;
int x = 0, y = 0;
bool directionsInvalid = false;

/*first try block reads directions from 'Adventurer Path.md'. Throws exception if file
is not found or no directions are found*/
try
{
    StreamReader sr = new StreamReader("../Adventurer Path.md");
    String? line = sr.ReadLine();
    while (line != null)
    {
        if(line.Length == 0)
        {
            line = sr.ReadLine();
            continue;
        }
        if(line[0] == '`')
        {
            directions = line.Substring(1, line.Length - 2);
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
}

/*this try block takes the directions and computes the destination coordinates on an x and y axis,
throws an exception if the direction set in invalid.*/
try{
    String numberOfSteps = string.Empty;
    for(int i = 0; i < directions.Length; i++)
    {
        if(Char.IsDigit(directions, i))
        {
            numberOfSteps += directions[i];
        }
        else
        {
            int steps;
            if(!Int32.TryParse(numberOfSteps, out steps))
            {
                throw new ArgumentException("Int32.TryParse failed to parse the steps. Make sure each direction has an integer for amount of steps directly before.");
            }
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
                throw new ArgumentException($"{directions[i]} is not a valid direction! Please use directions F, B, L, and R.");
            }
            numberOfSteps = string.Empty;
        }
    }
}
catch(Exception e)
{
    directionsInvalid = true;
    Console.WriteLine(e.Message);
}

/*finally, compute the euclidean distance using the destination x and y coordinates and 
print the output*/
try
{
    if(directionsInvalid)
    {
        throw new Exception("Parsing the directions failed.");
    }
    x = Math.Abs(x);
    y = Math.Abs(y);
    double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    Console.WriteLine(distance);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}