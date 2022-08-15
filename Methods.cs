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

        for (int i = 1; i < 61; i++)
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

        // The example requirement stated we should give seats from back to front.
        seats.Reverse();

        return Task.FromResult(seats);
    }

    public static bool FilledSeat()
    {
        Random random = new();

        // Will be true 30% of the time;
        if (random.Next(100) < 30)
        {
            return true;
        }

        return false;
    }

    public static void ShowGUI (List<Seat> seats)
    {
        Console.WriteLine("Seat List:");
        Console.WriteLine("");

        const string side = "|";
        int rowLength = 0;

        foreach (Seat seat in seats)
        {
            var availability = seat.Occupied ? "Taken " : "Free  ";
            var stringFormat = $"{side} {seat.Number} {availability}";

            if (seat.Number < 10)
            {
                stringFormat = $"{side} {seat.Number}  {availability}";
            }
            else if (rowLength == 5)
            {
                stringFormat = $"{side} {seat.Number}  {availability}{side}";
            }
            
            
            if (rowLength == 5 && seat.Number < 10)
            {
                stringFormat = $"{side} {seat.Number}  {availability} {side}";
            }


            if (rowLength == 5)
            {
                Console.WriteLine(stringFormat);
                rowLength = 0;
            }
            else
            {
                Console.Write(stringFormat);
                rowLength++;
            }
        }
        Console.WriteLine("");
    }

    public Task<List<Seat>> BookSeats (List<Seat> seats, int ticketCount, bool joinedSeats)
    {
        int filledSeats = 0;
        List<Seat> selectedSeats = new();

        if (joinedSeats)
        {
            foreach (Seat seat in seats)
            {
                if (!seat.Occupied)
                {
                    filledSeats++;
                    selectedSeats.Add(seat);
                }
                else
                {
                    filledSeats = 0;
                    // List is reset so we need to clear any existing items that were added.
                    selectedSeats.Clear();
                }

                if (filledSeats == ticketCount)
                    // In a real scenario would obviously change the availability of the purchased seats.
                    break;
            }

            if (filledSeats != ticketCount)
            {
                selectedSeats.Clear();
            }
        }
        else
        {
            foreach(Seat seat in seats)
            {
                if(!seat.Occupied)
                {
                    selectedSeats.Add(seat);
                    filledSeats++;

                    if (filledSeats == ticketCount)
                        // In a real scenario would obviously change the availability of the purchased seats.
                        break;
                }
            }
        }
        return Task.FromResult(selectedSeats);
    }
}
