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
			string[] Array = { "Unurgent", "ASAP", "Deadline" };
			TodoListpicker.ItemsSource = Array;
			string[] Times = { "15 min", "30 min", "1 hour", "2 hours", "3 hours", "4 hours", "6 hours", "12 hours" };
			TodoDuration.ItemsSource = Times;
        }

        private void Exit(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/WhatTodo.xaml", UriKind.Relative));
        }
    }
}