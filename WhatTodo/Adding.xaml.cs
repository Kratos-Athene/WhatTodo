using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WhatTodo
{
    public partial class Adding : PhoneApplicationPage
    {
        public Adding()
        {
            InitializeComponent();
        }

        private void Exit(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/WhatTodo.xaml", UriKind.Relative));
        }
    }
}