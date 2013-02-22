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
			InitializeCurrentTaskDisplay();
        }

		private void InitializeCurrentTaskDisplay() {
			List<Event> events = EventGiver.GetEvents();

			Event firstEvent = events.ElementAt(0);

			// Make a nice duration text
			TimeSpan duration = firstEvent.EndTime - firstEvent.StartTime;
			String durationTxt = "";

			if (duration.TotalMinutes >= 60) {
				// We need to show hours, too.
				durationTxt = duration.Hours + " hours, ";
			}
			durationTxt += duration.Minutes + " minutes";

			String endsText = firstEvent.EndTime.Hour + ":";
			if (firstEvent.EndTime.Minute < 10) {
				endsText += "0";
			}
			endsText += firstEvent.EndTime.Minute;
			String description = firstEvent.Info;

			// Update the UI components
			NextUpDurationText.Text = durationTxt;
			NextUpEndText.Text = endsText;
			NextUpDescriptionText.Text = description;
		}

		private void AddButtonClick(object sender, System.EventArgs e) {
			NavigationService.Navigate(new Uri("/Adding.xaml", UriKind.Relative));
		}

		private void WhatDidYouDoTap(object sender, System.Windows.Input.GestureEventArgs e) {
			NavigationService.Navigate(new Uri("/IsDone.xaml", UriKind.Relative));
		}
		
        private void SnoozeClicked(object sender, System.EventArgs e)
        {
			EventGiver.TakeABreak();
			EventGiver.NavigateToCorrectView(this);
        }
    }
}
