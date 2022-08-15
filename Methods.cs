namespace Ticket_Master_System;
internal class Methods
{

    /* 
        The example requirement stated that there are 6 seats in each row.
        And a total of 10 rows, meaning there are 60 seats.
     */ 
    public Task<List<Seat>> GenerateSeats()
    {
        List<Seat> seats = new();
        int seatsFilled = 0;
        int rowNumber = 1;

        if (seatsFilled == 6)
        {
            seatsFilled = 0;
            rowNumber++;
        }

        for (int i = 0; i < 60; i++)
        {
            Seat seat = new()
            {
                Number = i,
                RowNumber = rowNumber,
                Occupied = FilledSeat()
            };

            seats.Add(seat);
            seatsFilled++;
        }

        // The example requiment stated we should give seats from back to front.
        seats.Reverse();

        return Task.FromResult(seats);
    }

    public bool FilledSeat()
    {
        Random random = new();

        // Will be true 30% of the time;
        if (random.Next(100) < 40)
        {
            return true;
        }

        return false;
    }

    public Task<List<Seat>> BookSeats (List<Seat> seats, int ticketCount)
    {
        int availableSeats = 0;
        List<Seat> selectedSeats = new();

        foreach (Seat seat in seats)
        {
            if (!seat.Occupied)
            {
                availableSeats++;
                selectedSeats.Add(seat);
            }
            else
            {
                availableSeats = 0;
                // List is reset so we need to clear any existing items that were added.
                selectedSeats.Clear();
            }

            if (availableSeats == ticketCount)
                // In a real scenario would obviously change the availability of the purchased seats.
                break;
        }

        return Task.FromResult(selectedSeats);
    }
}
