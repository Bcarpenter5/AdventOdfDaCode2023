// See https://aka.ms/new-console-template for more information
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_1
{
    class Program

    {
        struct number
        {
            public string num;
            public int loc;
            public number(string num, int loc)
            {
                this.num = num;
                this.loc = loc;
            }

            public override string ToString()
            {
                if(num == "one") return "1";
                else if(num == "two") return "2";
                else if(num == "three") return "3";
                else if(num == "four") return "4";
                else if(num == "five") return "5";
                else if(num == "six") return "6";
                else if(num == "seven") return "7";
                else if(num == "eight") return "8";
                else if(num == "nine") return "9";
                else return "";
            }

        }
        static void Main(string[] args)
        {
            const int length = 1000;
            List<String> lines = File.ReadAllLines("input.txt").ToList();

            // lines = new List<string>() {
            //     "two1nine",
            //     "eightwothree",
            //     "abcone2threexyz",
            //     "xtwone3four",
            //     "4nineeightseven2",
            //     "zoneight234",
            //     "7pqrstsixteen",
            //     "4nine9twooneeightwoz"
            // };
            List<int> numbers = new List<int>();
            int temp = 0;
            int temp2 = 0;
            int num = 0;
            


            lines = lines.Select(x => {
                    List<char> n = new List<char>();

                    if(temp2++ < length)
                    {
                    Console.WriteLine();
                    Console.WriteLine("original: "+x);
                    }
                    string tempStr =  GetNumbers(x);
                    


                    tempStr.ToList().ForEach(y => {
                            if(Char.IsDigit(y))
                            {
                                n.Add(y);
                            }
                            });

                    if(n.Count > 2) n.RemoveRange(1, n.Count - 2);
                    else if(n.Count == 1) n.Add(n.First());
                    if(temp++ < length)
                    {
                        Console.WriteLine("Removed: "+ new string(n.ToArray()));
                    }
                    return new string(n.ToArray());
                    }).ToList();

            Console.WriteLine("lines: "+lines.Count);
            // for(int i = 0; i < length; i++)
            // {
            //     Console.WriteLine("orig: "+lines[i]+ " : "+ int.Parse(lines[i])+ " | count: " +i );
            //
            // }
            // // lines = lines.Select(x => x.First().ToString() + x.Last().ToString()).ToList();
            foreach(string line in lines)
            {
                if(int.TryParse(line, out num))
                {

                    numbers.Add(num);

                }
            }
            Console.WriteLine(numbers.Sum());
        }


        public static string GetNumbers(string input)
        {
            string output = "";
            int indexOfset = 0;
            List<number> nums = new List<number>();
            string[] numbers = new String[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int[] nums2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach(string number in numbers)
            {
                if(input.Contains(number))
                {
                    nums.Add(new number((number), input.IndexOf(number)));
                    if(input.LastIndexOf(number) != input.IndexOf(number))
                    {
                        nums.Add(new number((number), input.LastIndexOf(number)));
                    }
                }
            }
            nums = nums.OrderBy(x => x.loc).ToList();
            output = input;
            for(int i = 0; i < nums.Count; i++)
            {
                for(int j = 0; j < output.Length ; j++)
                {
                    if(j + indexOfset == nums[i].loc)
                    {
                         //Console.WriteLine("j: "+j+" | indexOfset: "+indexOfset+" | nums[i].loc: "+nums[i].loc);
                        output = output.Insert(j+indexOfset*2,nums[i].ToString());
                        indexOfset++;
                        break;
                    }
                }
            }
            Console.WriteLine(output);

            return output;
        }
    }
}
