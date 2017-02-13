using System;
using System.Windows.Forms;

namespace Placements.Kernel
{
    public class ListViewSorter : System.Collections.IComparer
    {
        public int Compare(object o1, object o2)
        {
            // Проверяем тип входных элементов
            if (!(o1 is ListViewItem))
                return (0);
            if (!(o2 is ListViewItem))
                return (0);

            // Получаем интересующие нас элементы
            ListViewItem lvi1 = (ListViewItem)o2;
            string str1 = lvi1.SubItems[ByColumn].Text;
            ListViewItem lvi2 = (ListViewItem)o1;
            string str2 = lvi2.SubItems[ByColumn].Text;

            // Сортируем числа
            double val1;
            double val2;
            if (double.TryParse(str1, out val1) && double.TryParse(str2, out val2))
            {
                if (val1 > val2)
                    return -1;
                else if (val1 < val2)
                    return 1;
                else
                    return 0;
            }

            // Сортируем строки
            int result;
            if (lvi1.ListView.Sorting == SortOrder.Ascending)
                result = String.Compare(str1, str2);
            else
                result = String.Compare(str2, str1);

            LastSort = ByColumn;

            return (result);
        }

        public int ByColumn
        {
            get { return Column; }
            set { Column = value; }
        }
        int Column = 0;

        public int LastSort
        {
            get { return LastColumn; }
            set { LastColumn = value; }
        }
        int LastColumn = 0;
    }
}
