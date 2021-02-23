using System;
using System.Collections.Generic; 
using System.Linq;

namespace The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());
            Queue<int> platesOfDefense = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> warriorPowers = new Stack<int>();
            for (int i = 0; i < wavesOfOrcs; i++)
            {
                warriorPowers = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
                if ((i + 1) % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    platesOfDefense.Enqueue(newPlate);
                }
                while (platesOfDefense.Count > 0 && warriorPowers.Count > 0)
                {
                    for (int j = 0; j < warriorPowers.Count; j++)
                    {
                            if (platesOfDefense.Count == 0)
                            {
                                break;
                            }
                        int plate = platesOfDefense.Peek();
                        int warriorPower = warriorPowers.Peek();

                        if (warriorPower > plate)
                        {
                            int newWarriorPower = warriorPower - plate;
                            platesOfDefense.Dequeue();
                            warriorPowers.Pop();
                            warriorPowers.Push(newWarriorPower);
                        }
                        else if (warriorPower < plate)
                        {
                            int newPlatePower = plate - warriorPower;
                            platesOfDefense.Dequeue();
                            warriorPowers.Pop();
                            platesOfDefense.Enqueue(newPlatePower);

                        }
                        else if (warriorPower == plate)
                        {
                            platesOfDefense.Dequeue();
                            warriorPowers.Pop();
                        }
                    }
                }
                if (platesOfDefense.Count == 0)
                {
                    break;
                }
            }
            if (platesOfDefense.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfDefense)}");
            }
            else if (warriorPowers.Any())
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", warriorPowers)}");
            }
        }
    }
}
