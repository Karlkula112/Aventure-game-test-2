using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_game_induvidual_project
{
    class Encounters
    {
        static Random rand = new Random();
        //Möten Generic 

        // Ormst
        public static void FirstEncounter()
        {
            Console.WriteLine("Den märkliga varelsen kommer allt snabbare och snabbare mot dig");
            Console.WriteLine("Du tar upp en linjal som du hde i din ficka.");


            Console.ReadKey();
            Combat(false, "Orm", 1, 4);
        }
        //Gullan
        public static void SecondEncounter()
        {
            Console.WriteLine("Någon kommer närmare dig, det är Gullan.");
            Console.WriteLine("Gullan blir arg och hoppar på dig dig");
            Console.ReadKey();
            Combat(false, "Gullan", 2, 6);

        }

       public static void BasicFighttEncounter()
        {
            Console.WriteLine("Du vänder dig runt höret och blir attakerad av ett monster...");
            Console.ReadKey();
            Combat(true,"",0,0);

        }
            
            
            // Mäten verktyg
        public static void RandomEncounter()
        {
            switch(rand.Next(0, 1))
            {
                case 0:
                    BasicFighttEncounter();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = rand.Next(1, 8);
                h = rand.Next(1, 10);
            }
            else
            {
                n = name;
                p = power;
                h = health;

            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|   (R)un (H)eal    |");
                Console.WriteLine("=====================");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {


                    {
                        // Atackera
                        Console.WriteLine("Du petar fienden med linjalen, " + n + " attackerade dig");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        int attack = rand.Next(0, Program.currentPlayer.weaponVaule) + rand.Next(1, 4);
                        Console.WriteLine("Du tog " + damage + " skada och gjorde " + attack + " skada");
                        Program.currentPlayer.health -= damage;
                        h -= attack;

                    }

                }
                if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    // Defend

                    Console.WriteLine("Du använder en ost bit som du hittar på marken föra att bli mer defensiv, ");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponVaule) / 2;
                    Console.WriteLine("Du tog " + damage + " skada och gjorde " + attack + " skada");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    // Run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("Du lägger en bas boost från " + n);
                        int damage = p - Program.currentPlayer.armorValue;
                        Program.currentPlayer.health -= damage;


                        Console.WriteLine("Du förlorade " + damage + " hp och ramlade");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Du la bas boosten och sprang snabbare än Usain Bolt");
                        Console.ReadKey();
                    }

                }
                if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // Heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("Du försöker hitta en potion i din bakficka men du hittar endast en kinesleksak");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine(n + "manglar dig och du tappar" + damage + "hp");
                    }
                    else
                    {
                        Console.WriteLine("Du drar ner handen i din bakficka och du hittar en glögg som du dricker");
                        int potionV = 5;
                        Console.WriteLine("Du får " + potionV + "hp");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potion -= 1;
                        //Player health cap
                        if (Program.currentPlayer.health > 10)
                            Program.currentPlayer.health = 10;





                        Console.ReadKey();

                    }

                 
                }
                Console.ReadKey();
                if (Program.currentPlayer.health <= 0)
                {
                    // Du dog medelande
                    Console.WriteLine("DU DOG");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }
            int c = rand.Next(10,50);
            Console.WriteLine("Eftersom du van över "+n+", fick du "+c+" guld mynt");
            Program.currentPlayer.coins += c;
            Console.ReadKey();

        }
        public static string GetName()
        {
            switch(rand.Next(0, 4))
            {
                case 0:
                    return "Orm";
                
                case 1: 
                    return "zombie";
           
                case 2: 
                    return "Spindel";

                case 3:
                    return "Skurk";

            }
            return "Galen människa";
        }
    }

}
