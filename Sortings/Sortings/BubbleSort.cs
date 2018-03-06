using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    internal class BubbleSort
    {
        public List<int> _elements;

        public BubbleSort(List<int> elements)
        {
            _elements = elements;
        }

        public void Sort()
        {
            for (int i = _elements.Count - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (_elements[j] > _elements[j + 1])
                        Common.Swap(_elements, j, j + 1);
                }
            }
        }
    }
}
