using System;

namespace DnD_Code
{
    internal class Program
    {
        static Random random = new Random();

        static void DnD()
        {
            int totStrength = 0;
            for (int index = 0; index < 3; index++)
            {
                int Strength = random.Next(1, 7);
                totStrength = totStrength + Strength;
            }
                Console.WriteLine($"A character with strength {totStrength} was created.");


            int CubeHealth = 0;
            for (int i = 0; i < 8; i++) 
            {
                int HealthCube = random.Next(1, 11);
                CubeHealth = CubeHealth + HealthCube; 
            }

            Console.WriteLine($"A gelatinous cube with {CubeHealth + 40} HP appeared!");


            int ArmyHealth = 0;
            for (int i = 0; i < 100; i++) 
            {
                for (int j = 0; j < 8; j++)
                {
                    int Army = random.Next(1, 11);
                    ArmyHealth = ArmyHealth + Army;
                }
                ArmyHealth = ArmyHealth + 40;
            }
            Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {ArmyHealth} HP! We are doomed!!");
        }
            
        static void Main(string[] args)
        {
            DnD();
        }
    }
}
