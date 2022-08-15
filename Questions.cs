namespace Ticket_Master_System;
internal class Questions
{
    public Task<int> AskTicketCount()
    {
        int ticketCount = 0;
        int ticketResult = 0;

        do
        {
            Console.WriteLine("How many tickets would you like to purchase? (1-6)");
            if (int.TryParse(Console.ReadLine(), out int ticketCountInput))
            {
                if (ticketCountInput > 6)
                {
                    Console.WriteLine("The maximum amount of tickets you can purchase is 6.");
                }
                else if (ticketCountInput < 1)
                {
                    Console.WriteLine("The number of tickets must be between 1 and 6.");
                }
                else
                {
                    ticketResult = ticketCountInput;
                    ticketCount++;
                }
            }
            continue;

        } while (ticketCount == 0);

        return Task.FromResult(ticketResult);
    }

    public Task<bool> AskJoinedSeats()
    {
        bool joinedSeats = false;
        int joinedResult = 0;

        do
        {
            Console.WriteLine("Do you want the seats to be joined? (Yes or No)");

            var input = Console.ReadLine();

            if (input == "Yes")
            {
                joinedSeats = true;
                joinedResult++;
                continue;
            }
            else if (input == "No")
            {
                joinedResult++;
                continue;
            }
            else
            {
                Console.WriteLine("The answer you provided was not acceptable, please try again.");
            }

        } while (joinedResult == 0);

        return Task.FromResult(joinedSeats);
    }
}
