using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequences = Console
                .ReadLine()
                .Split()
                .ToList(); //create aList of string and read the input

            int moves = 0;
            string letter = "a";
            string symbol = "-";

            while (true)
            {
                int middle = (sequences.Count) / 2;
                string inputLine = Console.ReadLine();

                if (inputLine == "end")
                {
                    Console.WriteLine($"Sorry you lose :(\n{string.Join(' ', sequences)}");
                    //ToDo
                    break;
                }

                moves++;

                string[] numParts = inputLine.Split();

                int firstIdx = int.Parse(numParts[0]);  // represent received idx
                int secIdx = int.Parse(numParts[1]);    // represent received idx

                if (firstIdx != secIdx && firstIdx >= 0 && secIdx >= 0 &&
                    firstIdx < sequences.Count && secIdx < sequences.Count)
                {
                    if (sequences[firstIdx] == sequences[secIdx])
                    {
                        Console.WriteLine($"Congrats! " +
                        $"You have found matching elements - {sequences[firstIdx]}!");

                        if (firstIdx > secIdx) //careful how remove elements,toRemove correctNum
                        {
                            sequences.RemoveAt(firstIdx);
                            sequences.RemoveAt(secIdx);
                        }
                        else  // secIdx > fristIdx
                        {
                            sequences.RemoveAt(secIdx);
                            sequences.RemoveAt(firstIdx);
                        }
                    }
                    else // if(sequence[firstIdx != sequence[secIdx]])
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else // try to lie or idx are invalid if 
                // (firstIdx == secIdx || firstIdx >= sequences.Count || secIdx > sequences.Count 
                // ||  firstIdx < 0 || secIdx < 0)
                {
                    sequences.Insert(middle, $"-{moves}a");
                    sequences.Insert(middle, (symbol + moves + letter)); //can be done this way too
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                if (sequences.Count <= 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }
            }
        }
    }
}
