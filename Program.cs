/*
 * Name: Sushma Penumala
 * Date: 01/30/2022
 * Description: Solution for 6 questions mentioned in Assignment 1
 * Self Reflection: It took me around 7 hrs to complete the assignment. The new concepts that I learned where throwing  exceptions and  if else  statements
 * It was a great  exploring the concepts of arrays
 * The concept of arrays was more clear.
 */
using System;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string : {0}", final_string);
            Console.WriteLine();

            //NEXT
            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };
            Console.WriteLine("Q2");
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            if (flag)
            {
                Console.WriteLine("Both the arrays represent the same string");
            }
            else
            {
                Console.WriteLine("Both the arrays do not represent the same string ");
            }
            Console.WriteLine();

            //NEXT

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements :{0}", unique_sum);
            Console.WriteLine();

            //NEXT

            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int dS = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is: {0}", dS);
            Console.WriteLine();

            //NEXT

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is: {0}", rotated_string);
            Console.WriteLine();

            //NEXT

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            Console.WriteLine("Q6:");
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Resultant string are reversing the prefix: {0}", reversed_string);
            Console.WriteLine();
        }

        private static string RemoveVowels(string s)
        {
            try
            {
                // write your code here
                int len = s.Length;//get the length of the string
                if (len > 10000)//user defined exceptions
                {
                    throw new MaxLength(len);
                }
                String final = "";
                foreach (char z in s)
                {
                    if (z != 'a' && z != 'e' && z != 'i' && z != 'o' && z != 'u' && z != 'A' && z != 'E' && z != 'I' && z != 'O' && z != 'U')//checking for vowels
                    {
                        final = final + z;
                    }
                }
                return final;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool ArrayStringsAreEqual(string[] bstring1, string[] bstring2)
        {
            try
            {
                string b1 = "";
                foreach (string s in bstring1)
                {
                    b1 = b1 + s;//concatination of  the strings in the first array
                }
                string b2 = "";
                foreach (string s in bstring2)
                {
                    b2 = b2 + s;//concatination of the strings in second array
                }
                if (b1 == b2)//comparision of the final strings
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static int SumOfUnique(int[] bb)
        {
            try
            {
                int len = bb.Length;//length of the string
                int[] x = bb;
                if (len > 100)//user defined exceptions
                {
                    throw new MaxLength(len);
                }
                foreach (int i in bb)//user defined exceptions
                {
                    if (i > 100)
                    {
                        throw new MaxValue(i);
                    }
                }
                int[] sample = new int[len];//create a new array
                int c = 0;
                for (int i = 0; i < len; i++)
                {
                    int n = bb[i];
                    if (sample.Contains(n))
                    {
                        c = c - n;//eliminating repeating elements
                    }
                    else
                    {
                        c = c + n;//adding unique elements
                        sample[i] = bb[i];//adding all the unique elements to the new array
                    }
                }
                return c;
            }
            catch
            {
                throw;
            }
        }
        private static int DiagonalSum(int[,] grid)
        {
            try
            {
                // write your code here.
                int l = Convert.ToInt32(Math.Sqrt(grid.Length));//get length/width of the matrix
                int s = 0;
                for (int i = 0; i < l; i++)//getting the diagonal elements
                {
                    for (int j = 0; j < l; j++)
                    {
                        if (i == j)
                        {
                            s = s + grid[i, j];//adding all left diagonal elements
                        }
                        else if (i + j == (l - 1))
                        {
                            s = s+ grid[i, j];//adding the right diagonal elements next
                        }
                    }
                }
                return s;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {
                int len = indices.Length;//get length of array
                if (len > 100)//user defined exceptions
                {
                    throw new MaxLength(len);
                }
                if (bulls_string.Length != indices.Length)//user defined exceptions
                {
                    throw new NotSame();
                }
                if (bulls_string.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Upper();
                }
                if (indices.Distinct().Count() != indices.Length)//user defined exceptions
                {
                    throw new Repeat();
                }
                foreach (int i in indices)
                {
                    if (i > bulls_string.Length)
                    {
                        throw new OutOflength();
                    }
                }
                string result = "";
                for (int i = 0; i < len; i++)
                {
                    int n = Array.IndexOf(indices, i);//getting index value from indices
                    result = result + bulls_string[n];//adding the character from the bull_string to the final string at the index obtained before
                }
                return result;//return string
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String prefix_string = "";
                int len = bulls_string6.Length;//get length of string
                if (bulls_string6.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Upper();
                }
                if (len > 250)//user defined exceptions
                {
                    throw new MaxLength(len);
                }
                int n = bulls_string6.IndexOf(ch, 0, len);//getting the index of the input character
                for (int i = n; i >= 0; i--)
                {
                    prefix_string = prefix_string + bulls_string6[i];//concat reverse part of the string
                }
                for (int i = n + 1; i < len; i++)
                {
                    prefix_string = prefix_string + bulls_string6[i];//concat the other part of the string
                }
                return prefix_string;//return string
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
[Serializable]
public class MaxLength : Exception
{
    public MaxLength(int l)
    {
        Console.WriteLine("Lenght of the input string should be lesser than" + l);
    }
}
public class MaxValue : Exception
{
    public MaxValue(int i)
    {
        Console.WriteLine("Value of the input shouldn't exceed 100, current value: " + i);
    }
}
public class Upper : Exception
{
    public Upper()
    {
        Console.WriteLine("Input string contains Upper case letter");
    }
}

public class Repeat : Exception
{
    public Repeat()
    {
        Console.WriteLine("All the values in indices array should be unique");
    }
}

public class NotSame : Exception
{
    public NotSame()
    {
        Console.WriteLine("Indices length and bull_string length aren't the same");
    }
}
public class OutOflength : Exception
{
    public OutOflength()
    {
        Console.WriteLine("Value in indices is exceeding the number of characters");
    }
}