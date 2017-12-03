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

                sum+= GetDiffPartOne(numbers);                
            }  
                        
            // Suspend the screen.  
            Console.WriteLine(sum);
        }

        private static int GetDiffPartOne(int[] values)
        {            
            return values.Max() - values.Min();;
        }        
    }
}
