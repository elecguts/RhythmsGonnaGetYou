using System;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmContext();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.Write("(L)ist bands.\n(Q)uit:\n ");
                var option = Console.ReadLine().ToUpper();

                switch (option)
                {

                    //Add a new band
                    case "L":
                        //View all the bands
                        Console.WriteLine("These are all the bands!");
                        foreach (var band in context.Bands)
                        {
                            Console.WriteLine($"There is a band named {band.Name}");
                        }
                        break;
                    //Add an album for a band
                    //Add a song to an album
                    //Let a band go (update isSigned to false)
                    //Resign a band (update isSigned to true)
                    //Prompt for a band name and view all their albums
                    //View all albums ordered by ReleaseDate
                    //View all bands that are signed
                    //View all bands that are not signed
                    case "Q":
                        //Quit the program
                        keepGoing = false;
                        break;
                }
            }
        }
    }
}
