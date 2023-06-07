using System;
using System.Diagnostics.Tracing;

namespace P06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string moviename;

            string movieType;
            double totalTicketCounter = 0;
            int totalKidsCounter = 0;
            int totalStudentCounter = 0;
            int totalStandardCounter = 0;
            double takenSeats = 0;
            int ticketCounter = 0;





            while ((moviename = Console.ReadLine()) != "Finish")
            {

                //double allSeats = 0;
                int allSeats = int.Parse(Console.ReadLine());
                {

                    //int allSeats = int.Parse(Console.ReadLine());
                    int kidsCounter = 0;
                    int studentCounter = 0;
                    int standardCounter = 0;


                    while (takenSeats <= allSeats)
                    {
                        for (takenSeats = 1; takenSeats <= allSeats; takenSeats++)
                        {
                            if ((movieType = Console.ReadLine()) == "End")
                            {
                                break;
                            }
                            else if (movieType == "kids")
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

                    Console.WriteLine($"{moviename} - {(totalTicketCounter / allSeats) * 100}% full.");
                }


            }

            if (moviename == "Finish")
            {
                Console.WriteLine($"Total tickets: {totalTicketCounter}");
                Console.WriteLine($"{(totalStudentCounter / totalTicketCounter) * 100}% student tickets.");
                Console.WriteLine($"{(totalStandardCounter / totalTicketCounter) * 100}% standard tickets.");
                Console.WriteLine($"{(totalKidsCounter / totalTicketCounter) * 100}% kids tickets.");
            }
        }
    }
}
