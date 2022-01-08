using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatAllocationProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public ProbabilityCalculator(int capacity, int numberOfTrials)
        {
            this.capacity = capacity;
            this.numberOfTrials = numberOfTrials;
        }

        private int capacity;
        private int numberOfTrials;


        public Dictionary<int, SeatInfo> InitState(IEnumerable<int> range)
        {
            Dictionary<int, SeatInfo> myState = new Dictionary<int, SeatInfo>();
            range.ToList().ForEach(x => myState.Add(x, new SeatInfo() { isEmpty = true, ticket = x }));
            return myState;
        }

        public int FindRandomSeat(Random random, int min, int max)
        {
            return random.Next(max - min + 1) + min;
        }

        public int FindEmptySeat(Dictionary<int, SeatInfo> state)
        {
            int result = 0;
            foreach (KeyValuePair<int, SeatInfo> entry in state)
            {
                if (entry.Value.isEmpty)
                {
                    result = entry.Key;
                    break;
                }
            }
            return result;
        }
        public double Calculate(int capacity, int numOfTrials)
        {

            Random random = new Random();
            int positiveTrialCount = 0;


            for (int n = 0; n < numOfTrials; n++)
            {

                IEnumerable<int> range = Enumerable.Range(1, capacity);
                Dictionary<int, SeatInfo> state = InitState(range);

                for (int tkt = 1; tkt <= capacity; tkt++)
                {

                    if (tkt == 1)
                    { //handle first passenger
                        SeatInfo seat = state[FindRandomSeat(random, 1, capacity)];
                        seat.isEmpty = false;
                        seat.ticket = tkt;

                        continue;
                    }

                    if (tkt == capacity)
                    { //decide if trial was successful
                        if (state[tkt].isEmpty)
                        {
                            positiveTrialCount++;
                        }
                    }

                    SeatInfo assignedSeat = state[tkt];
                    if (assignedSeat.isEmpty)
                    {      //if seat is empty, occupy your own seat
                        assignedSeat.isEmpty = false;
                        assignedSeat.ticket = tkt;
                    }
                    else
                    {
                        //take a random seat 
                        SeatInfo randomSeat = state[FindEmptySeat(state)];
                        randomSeat.isEmpty = false;
                        randomSeat.ticket = tkt;
                    }


                }


            }
            return ((double)positiveTrialCount) / numOfTrials; //calculate probability

        }
    }
}
