using System;
using System.Collections.Generic;
using System.Linq;

namespace problem_2
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(CountPasswords(138241, 674034));
    }
    
    static int CountPasswords(int min, int max) {
      var totalPasswords = 0;

      for (int num = min; num <= max; num++) {
        var digits = new List<int>(num.ToString().ToCharArray().Select((c) => int.Parse(c.ToString())));
        var prevDigit = -1;
        var hasDouble = false;
        var currentStreak = 1;
        var isIncreasing = true;

        foreach (var digit in digits) {
          if (digit < prevDigit) {
            isIncreasing = false;
            break;
          }
          else if (digit == prevDigit) {
            currentStreak++;
          }
          else {
            hasDouble = hasDouble || currentStreak == 2;
            currentStreak = 1;
          }
          prevDigit = digit;
        }
        hasDouble = hasDouble || currentStreak == 2;

        totalPasswords += (hasDouble && isIncreasing ? 1 : 0);
      }

      return totalPasswords;
    }
  }
}
