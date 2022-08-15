namespace Ticket_Master_System;

internal class Program
{
    static void Main(string[] args)
    {
        List<Seat> _seatList = new();
        Methods methods = new();

        Console.WriteLine("How many tickets would you like to purchase? (1-6)");
        int.TryParse(Console.ReadLine(), out int ticketCount);

        if (ticketCount == 0)
        {
            Console.WriteLine("The value you provided was not valid.");
            return;
        }

        _seatList = methods.GenerateSeats().Result;

        _seatList = methods.BookSeats(_seatList, ticketCount).Result;

        if (_seatList.Count == 0)
        {
            Console.WriteLine("We were unable to book the seats you wanted, please try again.");
            return;
        }

        Console.WriteLine("Your purchased seats are:");
        foreach (Seat seat in _seatList)
        {
            Console.WriteLine(seat.Number);
        }
    }

    /* Ideas / TODOs:
       1. Let user choose if they want the seats to be joined or not.
       2. Allow for tickets to be purchased on seperate rows.
       3. Print out a GUI diagram of the seats. 
    */
}
