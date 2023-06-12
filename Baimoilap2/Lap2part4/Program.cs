using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("SIN Validator");
        Console.WriteLine("=============");
        Console.Write("SIN (0 to quit): ");

        while (true)
        {
            string input = Console.ReadLine().Trim();
            if (input == "0")
            {
                Console.WriteLine("Have a Nice Day!");
                break;
            }

            int sin;
            if (!int.TryParse(input, out sin) || sin < 10000000 || sin > 999999999)
            {
                // Invalid input
                Console.WriteLine("Invalid SIN.");
                Console.Write("SIN (0 to quit): ");
                continue;
            }

            int checkDigit = sin % 10;
            sin /= 10;

            int weightedSum = 0;
            int sumOfOdds = 0;
            bool addEven = true;

            while (sin > 0)
            {
                int digit = sin % 10;

                if (addEven)
                {
                    int sum = digit * 2;
                    weightedSum += (sum % 10) + (sum / 10);
                }
                else
                {
                    sumOfOdds += digit;
                }

                addEven = !addEven;
                sin /= 10;
            }

            int total = weightedSum + sumOfOdds;
            int nextHighest = ((total / 10) + 1) * 10;
            int difference = nextHighest - total;

            if (difference == 10)
            {
                difference = 0;
            }

            if (difference == checkDigit)
            {
                Console.WriteLine("This is a valid SIN.");
            }
            else
            {
                Console.WriteLine("This is not a valid SIN.");
            }

            Console.Write("SIN (0 to quit): ");
        }
    }
}
