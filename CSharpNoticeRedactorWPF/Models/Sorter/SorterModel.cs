using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace CSharpNoticeRedactorWPF.Models.Sorter
{
    //Model that sorts ListBox items
    public class SorterModel : IDisposable
    {
        //Standart constructor
        public SorterModel() { }

        //Method that sorts elements in ListBox
        public void Sort(ListBox listBoxToSort, int comboBoxIndex)
        {
            if (comboBoxIndex == -1) //If sort does not selected
            {
                return;
            }

            if (comboBoxIndex == 0) //Sort by name (Ascending)
            {
                listBoxToSort.Items.SortDescriptions.Clear();
                listBoxToSort.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            else if (comboBoxIndex == 1) //Sort by name (Descending)
            {
                listBoxToSort.Items.SortDescriptions.Clear();
                listBoxToSort.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
            }
            else if (comboBoxIndex == 2) //Sort by creation date (Ascending)
            {
                listBoxToSort.Items.SortDescriptions.Clear();
                listBoxToSort.Items.SortDescriptions.Add(new SortDescription("CreationDate", ListSortDirection.Ascending));
            }
            else if (comboBoxIndex == 3) //Sort by creation date (Descending)
            {
                listBoxToSort.Items.SortDescriptions.Clear();
                listBoxToSort.Items.SortDescriptions.Add(new SortDescription("CreationDate", ListSortDirection.Descending));
            }
            else if (comboBoxIndex == 4) //Sort by text (Ascending)
            {
                listBoxToSort.Items.SortDescriptions.Clear();
                listBoxToSort.Items.SortDescriptions.Add(new SortDescription("Text", ListSortDirection.Ascending));
            }
            else if (comboBoxIndex == 5) //Sort by text (Descending)
            {
                listBoxToSort.Items.SortDescriptions.Clear();
                listBoxToSort.Items.SortDescriptions.Add(new SortDescription("Text", ListSortDirection.Descending));
            }
        }

        //Destructor
        public void Dispose() { }
    }
}
