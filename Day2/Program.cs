using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            
            string line;  
            // Read the file and display it line by line.  
            using(StreamReader file =  new StreamReader(@"input.txt"))  
            while((line = file.ReadLine()) != null)  
            {  
                string[] stringValues = line.Split('\t');
                int[] numbers = Array.ConvertAll(stringValues, s => int.Parse(s));

                //Part One
                //sum+= GetNumberPartOne(numbers);

                //Part Two
                sum+= GetNumberPartTwo(numbers);                
            }  
                        
            // Suspend the screen.  
            Console.WriteLine(sum);
        }

        private static int GetNumberPartOne(int[] values)
        {            
            return values.Max() - values.Min();
        }   

        private static int GetNumberPartTwo(int[] values)
        {            
            values = values.OrderByDescending(i => i).ToArray();

            int start = 1;
            for(int i=0;i<values.Length-1; i++)
            {
                for(int j=start;j<values.Length; j++)
                {
                    if(values[i] % values[j] == 0)
                    {
                        return values[i] / values[j];
                    }
                }

                start++;
            }

            throw new InvalidOperationException("Could not find a match");
        }        
    }
}
