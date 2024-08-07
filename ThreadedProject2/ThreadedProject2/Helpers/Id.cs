using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Gavin

namespace ThreadedProject2.Helpers
{
    internal class Id
    {
        /// <summary>
        /// Get's id ListBox lstData
        /// </summary>
        /// <param name="lstData">Used to create a substring from the selected item and parse</param>
        /// <returns></returns>
        static public int GetId(ListBox lstData)
        {
            int id = 0;
            {
                    if (!int.TryParse(lstData.SelectedItems[0].ToString().Substring(0, 6).TrimEnd(), out int value)) return -1;
                    id = int.Parse(lstData.SelectedItems[0].ToString().Substring(0, 6).TrimEnd());            }
            return id;
        }
    }
}
