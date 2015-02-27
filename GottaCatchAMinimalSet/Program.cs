using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GottaCatchAMinimalSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var pokemonList = ReadListFromFile();
            var bruteForce = new CharBasedAlgorithm();
            List<List<string>> minimalSets = bruteForce.Run(pokemonList);
            Console.WriteLine("{0} minimal sets found in {1} seconds:", minimalSets.Count, (DateTime.Now - startTime).TotalSeconds);
            foreach (var minimalSet in minimalSets)
            {
                Console.WriteLine(String.Join(", ", minimalSet));
            }
            Console.ReadLine();
        }

        static List<string> ReadListFromFile()
        {
            string json = File.ReadAllText(@"..\..\pokemon.txt");
            return JsonConvert.DeserializeObject<List<string>>(json);
        }
    }
}
