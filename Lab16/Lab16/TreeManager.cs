using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB10_lib;
using Lab12;
using Lab13;

namespace Lab16
{
    public class TreeManager
    {
        public TreeEvent<Place> tree { get; set; } // Сделайте свойство public

        public TreeManager()
        {
            tree = new TreeEvent<Place>("Бинарное дерево поиска");
        }

        public void FillCollection(int count)
        {
            for (int i = 0; i < count; i++) {
                var elem = new City();
                elem.RandomInit();
                try
                {
                    tree.Add(elem);
                }
                catch { i--; }
            }
        }

    }
}
