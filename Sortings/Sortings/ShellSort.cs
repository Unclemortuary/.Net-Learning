using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    internal class ShellSort
    {
        private List<int> _elements;

        public ShellSort(List<int> elements)
        {
            _elements = elements;
        }

        public void Sort()
        {
            int i, j = 0;
            int h = 1;
            int temp = 0;
            while (h <= _elements.Count / 3)
            {
                h = h * 3 + 1; // (1, 4, 13, 40)

                while (h > 0)
                {
                    for (j = h; j < _elements.Count; j++)
                    {
                        temp = _elements[j];
                        i = j;

                        while (i > h-1 && _elements[i - h] >= temp)
                        {
                            _elements[i] = _elements[i - 1];
                            i -= h;
                        }
                        _elements[i] = temp;
                    }
                    h = (h - 1) / 3;
                }
            }
        }
    }
}
