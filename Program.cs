namespace Ticket_Master_System;

internal class Program
{
    static void Main(string[] args)
    {
        Methods methods = new();
        Questions questions = new();
        List<Seat> _seatList = new();

        // Usually these types of calls would be asynchronous...

        // Initialize seat list data.
        _seatList = methods.GenerateSeats().Result;

        // Show seat diagram in the console.
        Methods.ShowGUI(_seatList);

        // Ask how many tickets the user wants.
        int ticketCount = questions.AskTicketCount().Result;

        // Ask if they want the seats they buy to be togther.
        bool joinedSeats = questions.AskJoinedSeats().Result;

        // Based on the users input, try to book seats with the users requirements.
        _seatList = methods.BookSeats(_seatList, ticketCount, joinedSeats).Result;

        if (_seatList.Count == 0)
        {
            Console.WriteLine("We were unable to book the seats you wanted, please try again.");
            return;
        }

        Console.WriteLine("Your seats are:");
        foreach (Seat seat in _seatList)
        {
            Console.WriteLine(seat.Number);
        }
    }

    /* Ideas / TODOs:
       1. Let user choose if they want the seats to be joined or not ✓✓
       2. Allow for tickets to be purchased on seperate rows. ?? (Might be silly).
       3. Print out a GUI diagram of the seats ✓✓
    */
}

