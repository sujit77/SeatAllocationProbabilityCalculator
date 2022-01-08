using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatAllocationProbabilityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // split the input args to read number of passenger capacity and number of trials 
            var inputs = args[0].Split(',');

            int capacity = int.Parse(inputs[0]);
            int numOfTrials = int.Parse(inputs[1]);            

            ProbabilityCalculator calc = new ProbabilityCalculator(capacity, numOfTrials);
            double probability = calc.Calculate(capacity, numOfTrials);
            Console.WriteLine("Probability: " + probability);
            Console.ReadKey();
        }
    }
}
