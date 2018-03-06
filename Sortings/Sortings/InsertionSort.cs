using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    internal class InsertionSort
    {
        private List<int> _elements;

        public InsertionSort(List<int> elements)
        {
            _elements = elements;
        }

        public void Sort()
        {
            for (int i = 1; i <= _elements.Count; i++)
            {
                int temp = _elements[i];
                int j = i;
                while (j > 0 && _elements[j - 1] >= temp)
                {
                    _elements[j] = _elements[j - 1];
                    j--;
                }
                _elements[j] = temp;
            }
        }
    }
}
