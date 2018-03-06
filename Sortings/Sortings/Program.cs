using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private List<int> GenerateRandValues(int count, int maxPossibleValue)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < count; i++)
            {
                result.Add(RandomValueGenerator(maxPossibleValue));
            }
            return result;
        }

        private int RandomValueGenerator(int range)
        {
            Random r = new Random();
            return r.Next(0, range);
        }

        private void DisplayList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item + Environment.NewLine);
            }
        }
    }
}
