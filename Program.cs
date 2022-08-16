namespace Ticket_Master_System;

internal class Program
{
    static void Main(string[] args)
    {
        Methods methods = new();
        Questions questions = new();
        List<Seat> seatList = new();

        // Usually these types of method calls would be asynchronous...

        // Initialize seat list data.
        seatList = methods.GenerateSeats();

        // Show seat diagram in the console.
        Methods.ShowGUI(seatList);

        // Ask how many tickets the user wants.
        int ticketCount = questions.AskTicketCount();

        // Ask if they want the seats they buy to be togther.
        bool joinedSeats = questions.AskJoinedSeats();

        // Based on the users input, try to book seats with the users requirements.
        seatList = methods.BookSeats(seatList, ticketCount, joinedSeats);

        if (seatList.Count == 0)
        {
            Console.WriteLine("We were unable to book the seats you wanted, please try again.");
            return;
        }

        string output = "Your seats are: ";

        foreach (Seat seat in seatList)
        {
            output = output + seat.Number + ", ";

            if (seatList.Last() == seat)
            {
                output = output + seat.Number + ".";
            }
        }
        Console.WriteLine(output);
    }

    /* Ideas / TODOs:
       1. Let user choose if they want the seats to be joined or not ✓✓
       2. Allow for tickets to be purchased on seperate rows. ?? (Might be silly).
       3. Print out a GUI diagram of the seats ✓✓
    */
}

