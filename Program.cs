using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                Console.WriteLine();
                Console.Write("(1)List bands\n(2)Add a band\n(3)Add an album for a band\n(4)Add a song to an album\n");
                Console.Write("(5)Let a band go\n(6)Resign a band\n(7)Search for albums by band name\n");
                Console.Write("(8)View all albums by release date\n(9)View all bands that are signed\n(10)View all bands that are unsigned\n");
                Console.Write("(11)Quit: ");
                var option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        //View all the bands
                        Console.WriteLine("These are all the bands!");
                        foreach (var band in context.Bands)
                        {
                            Console.WriteLine($"There is a band named {band.Name}");
                        }
                        break;
                    case "2":
                        //Add a new band
                        Console.Write("What is the name of the new band? ");
                        var name = Console.ReadLine();
                        Console.Write("What is the country of origin? ");
                        var countryOfOrigin = Console.ReadLine();
                        Console.Write("How many members are in the band? ");
                        var numberOfMembers = int.Parse(Console.ReadLine());
                        Console.Write("What is the website? ");
                        var website = Console.ReadLine();
                        Console.Write("What style is the band? ");
                        var style = Console.ReadLine();
                        var isSigned = false;
                        Console.Write("Who can we contact about this band? ");
                        var contactName = Console.ReadLine();
                        Console.Write("What number can we use to get in touch with the contact? (No spaces or symbols please)");
                        var contactPhoneNumber = double.Parse(Console.ReadLine());

                        var newBand = new Band
                        {
                            Name = name,
                            CountryOfOrigin = countryOfOrigin,
                            NumberOfMembers = numberOfMembers,
                            Website = website,
                            Style = style,
                            IsSigned = isSigned,
                            ContactName = contactName,
                            ContactPhoneNumber = contactPhoneNumber
                        };

                        context.Bands.Add(newBand);
                        context.SaveChanges();
                        break;
                    case "3":
                        //Add an album for a band
                        foreach (var band in context.Bands)
                        {
                            Console.WriteLine($"{band.Id} - {band.Name}");
                        }
                        Console.WriteLine("What band is this album by? ");
                        var bandIdForNewAlbum = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the title of the album?");
                        var title = Console.ReadLine();
                        Console.WriteLine("Is this album explicit? (y/n)?");
                        var explicitChoice = Console.ReadLine().ToUpper();
                        var isExplicit = false;
                        if (explicitChoice == "Y")
                        {
                            isExplicit = true;
                        }
                        Console.WriteLine("What date was this album released?(mm/dd/yyyy)");
                        var releaseDate = (DateTime.Parse(Console.ReadLine())).ToUniversalTime();

                        var newAlbum = new Album
                        {
                            Title = title,
                            IsExplicit = isExplicit,
                            ReleaseDate = releaseDate,
                            BandId = bandIdForNewAlbum
                        };

                        context.Albums.Add(newAlbum);
                        context.SaveChanges();
                        break;
                    case "4":
                        //Add a song to an album
                        Console.WriteLine("This option adds a song to an album");
                        break;
                    case "5":
                        //Let a band go (update isSigned to false)
                        var signedBandsToLetGo = context.Bands.Where(band => band.IsSigned == true);
                        foreach (var band in signedBandsToLetGo)
                        {
                            Console.WriteLine($"{band.Id} - {band.Name}");
                        }
                        Console.Write("Which band is being let go?");
                        var bandChoice = int.Parse(Console.ReadLine());
                        var bandToLetGo = context.Bands.FirstOrDefault(band => band.Id == bandChoice);
                        if (bandToLetGo != null)
                        {
                            bandToLetGo.IsSigned = false;
                            context.SaveChanges();
                        }
                        break;
                    case "6":
                        //Resign a band (update isSigned to true) 
                        var unsignedBandsToResign = context.Bands.Where(band => band.IsSigned == false);
                        foreach (var band in unsignedBandsToResign)
                        {
                            Console.WriteLine($"{band.Id} - {band.Name}");
                        }
                        Console.Write("Which band is being resigned?");
                        var bandChoiceResign = int.Parse(Console.ReadLine());
                        var bandToResign = context.Bands.FirstOrDefault(band => band.Id == bandChoiceResign);
                        if (bandToResign != null)
                        {
                            bandToResign.IsSigned = true;
                            context.SaveChanges();
                        }
                        break;
                    case "7":
                        //Prompt for a band name and view all their albums
                        Console.WriteLine("This option takes a band name and returns all albums by that band");
                        break;
                    case "8":
                        //View all albums ordered by ReleaseDate
                        Console.WriteLine("This option shows all albums, ordered by release date");
                        break;
                    case "9":
                        //View all bands that are signed
                        var signedBands = context.Bands.Where(band => band.IsSigned == true);
                        foreach (var band in signedBands)
                        {
                            Console.WriteLine($"There is a signed band named {band.Name}");
                        }
                        break;
                    case "10":
                        //View all bands that are not signed
                        var unsignedBands = context.Bands.Where(band => band.IsSigned == false);
                        foreach (var band in unsignedBands)
                        {
                            Console.WriteLine($"There is an unsigned band named {band.Name}");
                        }
                        break;
                    case "11":
                        //Quit the program
                        keepGoing = false;
                        break;
                }
            }
        }
    }
}
