﻿using System;
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
			int i = 0;
			cal.Events.ForEach(delegate(Event testEvent) 
			{
				if (i++ < 10)
				{
					TestEventContent(testEvent);
				}
			});
        }

        private void TestEventContent(Event testEvent)
        {
			Debug.WriteLine(testEvent.Name);
			Debug.WriteLine(testEvent.StartTime);
			Debug.WriteLine(testEvent.EndTime);
        }
    }
}