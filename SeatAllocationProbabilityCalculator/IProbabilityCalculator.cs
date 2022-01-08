using System;
using System.Collections.Generic;

namespace SeatAllocationProbabilityCalculator
{
    public interface IProbabilityCalculator
    {
        double Calculate(int capacity, int numOfTrials);
        int FindEmptySeat(Dictionary<int, SeatInfo> state);
        int FindRandomSeat(Random random, int min, int max);
        Dictionary<int, SeatInfo> InitState(IEnumerable<int> range);
    }
}