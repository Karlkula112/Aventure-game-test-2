using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_game_induvidual_project
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainloop = true;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Start();
            Encounters.FirstEncounter();
            Console.Clear();
            AfterFE();
            Encounters.SecondEncounter();
            while (mainloop)
            {
                Encounters.RandomEncounter();
            }
           
        }
  
        static void Start()
        {
            Console.WriteLine("Gaddis - The legend of Ormst");
            Console.WriteLine("Name:");
            currentPlayer.name = Console.ReadLine();
            Console.WriteLine("Du vaknar, du vet inte vart du är. Omgivningen är mörk och kall, lång bort i fjärran ser du något som lyser.");
            Console.WriteLine("Du märker att det står något på din arm");
            if (currentPlayer.name == "")
                Console.WriteLine("Det verkar vara utsuddat");
            else
                Console.WriteLine("Det är ditt namn: " + currentPlayer.name);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Du bestämmer dig för att gå mot ljuset. Du börjar ditt äventyr");
            Console.WriteLine("På vägen så hör du något som slingrar sig i gräset. ");
            Console.WriteLine("Den får syn på dig och den börjar röra sig mot dig");
            
        }   

        static void AfterFE()
        {
            Console.WriteLine("Efter din strid mot ormen bestämmer du dig för att gå vidare.");
            Console.WriteLine("Du hör woof.");
            Console.ReadKey();
            Console.Clear();
           
        }

    
    
    }
}
