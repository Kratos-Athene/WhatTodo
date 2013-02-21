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
using System.Diagnostics;

namespace WhatTodo
{
    public partial class MainPage : PhoneApplicationPage
    {
        WPCal cal;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            cal = new WPCal(TestWPCal);
            cal.LoadUserEvents();

            Debug.WriteLine("starting");
        }

        void TestWPCal()
        {
            Event testEvent = cal.Events.ForEach(TestEventContent);
        }

        private Event TestEventContent(Event testEvent)
        {
            Debug.WriteLine(testEvent.StartTime.ToString());

            return testEvent;
        }
    }
}