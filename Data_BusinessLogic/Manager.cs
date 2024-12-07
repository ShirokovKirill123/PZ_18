using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Data_BusinessLogic
{
    internal class Manager
    {
        public static Frame MainFrame { get; set; }
        public static void Navigate(Page page)
        {
            MainFrame.Navigate(page);
        }

        public static void GoBack()
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}
