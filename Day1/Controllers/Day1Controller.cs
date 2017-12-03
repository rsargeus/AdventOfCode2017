using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    public class Day1Controller : Controller
    {
        // GET api/values/5
        [HttpGet("{input}")]
        public string Get(string input)
        {
            
            char[] charArray = input.ToCharArray();
            int[] intArray = Array.ConvertAll(charArray, c => (int)Char.GetNumericValue(c));        
            

            //Part One
            //int steps = 1;            
            
            //Part Two
            int steps = intArray.Length / 2;

            int sum = 0;
            for(int i=0; i<intArray.Length; i++)
            {
                
                int p = (i+steps) % intArray.Length;
                
                int nextInt = intArray[p];
                                
                if(intArray[i] == nextInt)
                {
                    sum+=intArray[i];
                }
            }
            
            return sum.ToString();
        }                
    }
}
