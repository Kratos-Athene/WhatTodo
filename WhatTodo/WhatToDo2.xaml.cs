using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WhatTodo
{
    public partial class WhatToDo2 : PhoneApplicationPage
    {
        public WhatToDo2()
        {
            InitializeComponent();
        }

        private void SnoozeClicked(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/WhatToDo.xaml", UriKind.Relative));
        }
    }
}
