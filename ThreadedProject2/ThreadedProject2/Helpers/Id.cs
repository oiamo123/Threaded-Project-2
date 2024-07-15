using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedProject2.Helpers
{
    internal class Id
    {
        static public int GetId(ListBox lstData)
        {
            int id = 0;
            {
                if (!int.TryParse(lstData.SelectedItems[0].ToString().Substring(0, 6).TrimEnd(), out int value)) return -1;
                id = int.Parse(lstData.SelectedItems[0].ToString().Substring(0, 6).TrimEnd());
            }
            return id;
        }
    }
}
