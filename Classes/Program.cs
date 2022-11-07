using System;
using System.Collections.Generic;

namespace Classes
{
    internal class Program
    {
        static Random random = new Random();
        class Location
        {
            public string Name;
            public string Description;
            public List<Location> Neighbours = new List<Location>();
        }

        static void ConnectLocations(Location a, Location b)
        {
            a.Neighbours.Add(b);
            b.Neighbours.Add(a);
        }

        static void Main(string[] args)
        {
            var locations = new List<Location>();

            var thunderingFalls = new Location
            {
                Name = "Thundering Falls",
                Description = "a giant waterfall dominates this island with its thundering sound."
            };

            locations.Add(thunderingFalls);

            var scarletLagoon = new Location
            {
                Name = "Scarlet Lagoon",
                Description = "this shallow lagoon is characterized by its scarlet waters."
            };

            locations.Add(scarletLagoon);

            var poseidonsThrone = new Location
            {
                Name = "Poseidon's Throne",
                Description = "the long forgotten seat of Poseidon."
            };

            locations.Add(poseidonsThrone);

            var ramatan = new Location
            {
                Name = "Ramatan",
                Description = "this island is covered by a ferocious jungle."
            };

            locations.Add(ramatan);

            var sinclairsDespair = new Location
            {
                Name = "Sinclair's Despair",
                Description = "the island where Sinclair met his gruesome fate."
            };

            locations.Add(sinclairsDespair);

            var rumCove = new Location
            {
                Name = "Rum Cove",
                Description = "home to the finest stash of delectable rum in the ASCII-sea."
            };

            locations.Add(rumCove);

            //Connecting Locations
            ConnectLocations(scarletLagoon, thunderingFalls);
            ConnectLocations(scarletLagoon, rumCove);
            ConnectLocations(scarletLagoon, ramatan);
            ConnectLocations(thunderingFalls, poseidonsThrone);
            ConnectLocations(ramatan, rumCove);
            ConnectLocations(ramatan, sinclairsDespair);
            ConnectLocations(poseidonsThrone, sinclairsDespair);
            ConnectLocations(poseidonsThrone, rumCove);
            ConnectLocations(sinclairsDespair, rumCove);
           
            
            //Creating the Current Location
            int startingLocation = random.Next(0, 6);
            Location currentLocation = locations[startingLocation];

            while (true)
            {
                //Displaying the Current Location
                Console.WriteLine($"Welcome to {currentLocation.Name}, {currentLocation.Description}");
                Console.WriteLine();
                Console.WriteLine($"Available trade routes are:");
                for (int i = 0; i < currentLocation.Neighbours.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentLocation.Neighbours[i].Name}");
                }

                //Ask Player
                Console.WriteLine();
                Console.WriteLine("Where would you like to go?");

                string chosenRoute = Console.ReadLine();
                int route = Convert.ToInt32(chosenRoute);
                currentLocation = currentLocation.Neighbours[route-1];
                Console.Clear();
            }
        }
    }
}
