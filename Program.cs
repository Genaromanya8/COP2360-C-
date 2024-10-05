using System;
using System.IO.Pipes;
using System.Linq.Expressions;

public class IndividualProject
{
    static void Main(string[] args)
    {
        Console.WriteLine("I will help you to divide two numbers");

        Console.WriteLine("Enter the first number");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string input1 = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        Console.WriteLine("Enter the second number");
        string input2 = Console.ReadLine();
        try
        {
            int answer1 = Convert.ToInt32(input1);
            int answer2 = Convert.ToInt32(input2);

            int result = answer1 / answer2;
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: One of the inputs is not a valid number.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        
        catch (OverflowException ex)
        {
            Console.WriteLine("Error: the number is to large");
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

}
