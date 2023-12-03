using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Advent_2nd
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = File.ReadAllLines("input.txt").ToList();
            // input = new List<string>()
            // {
            //     "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            //         "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            //         "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            //         "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            //         "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            // };
            List<BagBall> bagBalls = new List<BagBall>();
            foreach(string s in input){
                bagBalls.Add(new BagBall(s));
                Console.WriteLine("------------------------------------------------");

            }
            int sum = bagBalls.Where(x => x.isValid).Sum(x => x.gameNumber);
            Console.WriteLine(sum);
            Console.WriteLine(BagBall.PowTotal);

        }
    }

    class BagBall{
        public static int PowTotal = 0;
        const int MAX_RED = 12;
        const int MAX_GREEN = 13;
        const int MAX_BLUE = 14;

        public int red = 0;
        public int green = 0;
        public int blue = 0;
        public bool isValid = true;
        public int gameNumber;
        public int Pow;

        

        public BagBall(string input){
            input =input.Remove(0,4);
            Console.WriteLine(input);
            gameNumber = int.Parse(input.Substring(0,input.IndexOf(":")));
            Console.WriteLine("Game Number: " + gameNumber);
            input = input.Substring(4, input.Length - 4);
            Console.WriteLine(input);
            String[] bags = input.Split(";");
            for(int i = 0; i < bags.Length; i++){
                bags[i] = bags[i].Insert(0," ");
                int temp = 0;
                if(bags[i].Contains("red")){
                    temp = int.Parse(bags[i].Substring(bags[i].IndexOf("red") - 3,2).Trim());
                    red = Math.Max(red, temp);
                    
                }
                if(bags[i].Contains("green")){
                    temp = int.Parse(bags[i].Substring(bags[i].IndexOf("green") - 3,2).Trim());
                    green = Math.Max(green, temp);
                }
                if(bags[i].Contains("blue")){
                    temp = int.Parse(bags[i].Substring(bags[i].IndexOf("blue") - 3,2).Trim());
                    blue = Math.Max(blue, temp);
                }
                Console.WriteLine(red + " " + green + " " + blue);
                if(red > MAX_RED || green > MAX_GREEN || blue > MAX_BLUE){
                    isValid = false;
                }
            }
            Pow = red*blue*green;
            PowTotal += Pow;
            
            Console.WriteLine(isValid);
        }
    }




}
