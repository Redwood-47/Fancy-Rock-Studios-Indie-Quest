using System;

class Example
{
    // Create a TimeSpan object and display its value.
    static void CreateTimeSpan(int hours, int minutes, int seconds)
    {
        TimeSpan elapsedTime = new TimeSpan(hours, minutes, seconds);

        // Format the constructor for display.
        string ctor = String.Format("TimeSpan( {0}, {1}, {2}" +  ")", hours, minutes, seconds);

        // Display the constructor and its value.
        Console.WriteLine("{0,-44}{1,16}", ctor, elapsedTime.ToString());
    }

    static void Main()
    {
        Console.WriteLine("{0,-44}{1,16}", "Constructor", "Value");
        Console.WriteLine("{0,-44}{1,16}", "-----------", "-----");

        CreateTimeSpan(20, 30, 40);
        CreateTimeSpan(20, 30, 40);
        CreateTimeSpan(0, 0, 937840);
        CreateTimeSpan(2000, 3000, 4000);
        CreateTimeSpan(-2000, -3000, -4000);
        CreateTimeSpan(999999, 999999, 999999);
    }
}