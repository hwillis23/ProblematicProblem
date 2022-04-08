using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static bool cont = true; 

        static  List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
           
            
                Random rng = new Random(); //this method needs to be instanciatied (= new Random ();) needs to be in the main method

                Console.WriteLine("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
                var contResponse = Console.ReadLine().ToLower();
                bool cont;

                if (contResponse == "yes")
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                    //Environment.Exit (0);   makes immediately exit the program
                }

                Console.WriteLine();

                Console.WriteLine("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine().ToLower();
                Console.WriteLine();
                Console.WriteLine("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());  //CRL takes input as a "string"  int userage = Convert.ToInt32(C.RL());
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = (Console.ReadLine().ToLower() == "sure") ? true : false;

                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);  //in () put in how mnay miliseconds 
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList =(Console.ReadLine().ToLower() == "yes") ? true : false;

                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();

                        Console.WriteLine("Would you like to add more? yes/no: ");

                        addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;

                    }
                }
                string randomActivity;

                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();

                    int randomNumber = rng.Next(activities.Count);  //.Next to generate a random number

                     randomActivity = activities[randomNumber];

                    if (userAge <= 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");

                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);

                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }

                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();

                    cont = (Console.ReadLine().ToLower() == "redo") ? true : false;


                }
            
        }
    }

}
