/*
	Euler Project 30
	
	AUTHOR:
		Paweł Gancarz, PK Mech, 13K3
	
	PROGRAMMING LANGUAGE:
		C#
	
	CONDING STANDARD:
		C# Coding Convention
*/

using System.IO;
using System;


class Program
{
    static void Main()
    {
		Euler30 euler = new Euler30();
		euler.Compute();
		
		Console.WriteLine(euler.Result);
    }
}

/// <summary>
/// Class for computing the sum of all the numbers that can be written as the sum of fifth powers of their digits
/// </summary>
public class Euler30
{
    private int result;
    public int Result
    {
        get
        {
            return result;
        }
    }
    
    /// <summary>
    /// Constructor
	/// </summary>
    public Euler30()
    {
        result = 0;
    }
    
    /// <summary>
    /// Computes exponential values
	/// <params name="baseNumber">the base</params>
	/// <params name="exponent">the exponent</params>
	/// <returns>The value of the first argument raised to the power of the second argument<returns>
	/// </summary>
	private static int GetPower(int baseNumber, int exponent)
	{
		int multiplier = baseNumber;
		
		//small loop to make the nth power of the digit as this is faster than using the math.pow function
		for(int i = 1; i < exponent; i++)
		{
			baseNumber *= multiplier;
		}
		
		return baseNumber;
	}
	
	/// <summary>
	/// Computes the sum of each digit in number
	/// <params name="number">base number</params>
	/// <params name="digitCount">Count of digits in number</params>
	/// </summary>
	private int SumOfDigit(int number, int digitCount)
	{
	    int sumOfPowers = 0;
	    
	    while (number > 0) 
		{
		    // computes the remainder after dividing its first operand by its second
			int remainder = number % 10;
			number /= 10;

			remainder = GetPower(remainder, 5);
			
			sumOfPowers += remainder;
		}
		
		return sumOfPowers;
	}
	
	/// <summary>
	/// Computes the sum of all the numbers that can be written as the sum of fifth powers of their digits
	/// </summary>
	public void Compute()
	{
	    result = 0;
	    
	    for (int i = 2; i < 355000; i++) 
		{
            int sumOfPowers = 0;
            int number = i;
            
            // loop for each digit in number
			sumOfPowers = SumOfDigit(number, 5);
            
			if (sumOfPowers == i) 
			{
				result += i;
			}
		}
	}
}
