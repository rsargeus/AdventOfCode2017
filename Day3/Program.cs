using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    class Program
    {
        
        internal class Item  
        {  
            internal int x;  
            internal int y;  
            internal int value;  
            
            internal char dir;  

            internal Item(int x, int y, char dir)
            {
                this.x = x;
                this.y = y;                
                this.dir = dir;
            }

            public override string ToString()
            {
                return string.Format("{0} ({1},{2}) {3}", value, x, y, dir);
            }            
        }  
        
        static List<Item> items = new List<Item>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            int max = 5;            
            int circle=1;

            Item currentItem = new Item(0,0, 'S');
            currentItem.value = 1;

            items.Add(currentItem);

            while(circle < max)
            {
                
                currentItem = CreateRight(currentItem, circle);
                currentItem = CreateTop(currentItem, circle);
                currentItem = CreateLeft(currentItem, circle);
                currentItem = CreateBottom(currentItem, circle);
                                
                circle++;
            }


            foreach(Item item in items)
            {
                Console.WriteLine(item);

            }

        }

        static Item CreateRight(Item prev, int circle)
        {
            Item currentItem = prev;
            
            for(int i=0; i<circle*2; i++)
            {
                currentItem = new Item(prev.x+1, prev.y+i, 'R');
                currentItem.value = GetValue(currentItem);
                items.Add(currentItem);
            }
        
            return currentItem;
        }

        static Item CreateTop(Item prev, int circle)
        {
            Item currentItem = prev;
            
            for(int i=0; i<circle*2; i++)
            {
                currentItem = new Item(prev.x-(1+i), prev.y, 'T');
                currentItem.value =  GetValue(currentItem);
                items.Add(currentItem);
            }
        
            return currentItem;
        }

        static Item CreateLeft(Item prev, int circle)
        {
            Item currentItem = prev;
            
            for(int i=0; i<circle*2; i++)
            {
                currentItem = new Item(prev.x, prev.y - (1+i), 'L');
                currentItem.value =  GetValue(currentItem);
                items.Add(currentItem);
            }
        
            return currentItem;
        }

        static Item CreateBottom(Item prev, int circle)
        {
            Item currentItem = prev;
            
            for(int i=0; i<circle*2; i++)
            {
                currentItem = new Item(prev.x + (1+i), prev.y, 'B');
                currentItem.value =  GetValue(currentItem);
                items.Add(currentItem);
            }
        
            return currentItem;
        }
        
        
        //Part One
        
        static int partOneCounter = 1;
        static int GetValuePartOne(Item item)
        {
            return ++partOneCounter;
        }
        
        //Part two
        static int GetValue(Item item)
        {
            
            Item[] adjacentItems = new Item[8];

            //North
            adjacentItems[0] = items.Where(i => i.x == item.x && i.y==item.y+1 ).SingleOrDefault();
            
            //North east
            adjacentItems[1] = items.Where(i => i.x == item.x+1 && i.y==item.y+1 ).SingleOrDefault();
            
            //East
            adjacentItems[2] = items.Where(i => i.x == item.x+1 && i.y==item.y ).SingleOrDefault();
            
            //South east
            adjacentItems[3] = items.Where(i => i.x == item.x+1 && i.y==item.y-1 ).SingleOrDefault();
            
            //South
            adjacentItems[4] = items.Where(i => i.x == item.x && i.y==item.y-1 ).SingleOrDefault();

            //South west
            adjacentItems[5] = items.Where(i => i.x == item.x-1 && i.y==item.y-1 ).SingleOrDefault();

            //West
            adjacentItems[6] = items.Where(i => i.x == item.x-1 && i.y==item.y ).SingleOrDefault();
            
            //North west
            adjacentItems[7] = items.Where(i => i.x == item.x-1 && i.y==item.y+1 ).SingleOrDefault();
            

            int sum = 0;
            foreach(Item adjacentItem in adjacentItems)
            {
                if(adjacentItem != null)
                {
                      sum += adjacentItem.value;  
                }
            }            
            
            return sum;
        }
        
        static void Main2(string[] args)
        {
            
            int find = 1024;
            
            Console.WriteLine("Hello World!");
            int steps = 1;
            
            int circle=0;
            
            while(steps < find)
            {
                circle++;
                
                int a = (circle*2+1) * 4 - 4;                
                steps += a;                
                Console.WriteLine("{0} circle: {1} steps: {2} total", circle, a, steps);                
            }

            Console.WriteLine("{0} steps total in {1} circles", steps, circle);                


            int circlelength = circle * 8;


            int[] alternatives = new int[4];
            
            //south
            alternatives[0] = Math.Abs((steps - circlelength / 8) % find);            
            //east
            alternatives[1] = Math.Abs((alternatives[0] - circlelength / 4) % find);            
            //north
            alternatives[2] = Math.Abs((alternatives[1] - circlelength / 4) % find);            
            //west
            alternatives[3] = Math.Abs((alternatives[2] - circlelength / 4) % find);

            Console.WriteLine("Best option is {0} steps extra  ", alternatives.Min());                


            Console.WriteLine("Total numbers of steps for {0} is {1}", find, alternatives.Min() + circle);





            /*
            
            Första cirkeln
            1 (1)
            Andra cirkeln
            2-9 (3)
            Andra cirkeln
            10 (5) - 5*4-4 = 16 
            
             */

            

        }

        
    }
}
