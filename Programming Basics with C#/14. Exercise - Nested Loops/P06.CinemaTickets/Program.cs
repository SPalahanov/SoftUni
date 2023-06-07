using System;

namespace P06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string moviename;

            string movieType;
            double totalTicketCounter = 0;
            double totalKidsCounter = 0;
            double totalStudentCounter = 0;
            double totalStandardCounter = 0;




            while ((moviename = Console.ReadLine()) != "Finish")
            {

                int allSeats = int.Parse(Console.ReadLine());

                int kidsCounter = 0;
                int studentCounter = 0;
                int standardCounter = 0;
                double ticketCounter = 0;
                double totalCounter = 0;
                int takenSeats = 0;


                while (takenSeats < allSeats)
                {

                    for (takenSeats = 1; takenSeats <= allSeats; takenSeats++)
                    {
                        if ((movieType = Console.ReadLine()) == "End")
                        {
                            break;
                        }
                        else if (movieType == "kid")
                        {
                            kidsCounter++;
                        }
                        else if (movieType == "student")
                        {
                            studentCounter++;
                        }
                        else if (movieType == "standard")
                        {
                            standardCounter++;
                        }
                        ticketCounter++;
                    }
                    if (takenSeats < allSeats)
                    {
                        break;
                    }
                }
                totalKidsCounter += kidsCounter;
                totalStudentCounter += studentCounter;
                totalStandardCounter += standardCounter;
                totalTicketCounter += ticketCounter;
                totalCounter += ticketCounter;
                Console.WriteLine($"{moviename} - {((totalCounter / allSeats) * 100):f2}% full.");

            }

            if (moviename == "Finish")
            {
                Console.WriteLine($"Total tickets: {totalTicketCounter}");
                Console.WriteLine($"{((totalStudentCounter / totalTicketCounter) * 100):f2}% student tickets.");
                Console.WriteLine($"{((totalStandardCounter / totalTicketCounter) * 100):f2}% standard tickets.");
                Console.WriteLine($"{((totalKidsCounter / totalTicketCounter) * 100):f2}% kids tickets.");
            }
        }
    }
}
