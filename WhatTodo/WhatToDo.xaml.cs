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

namespace WhatTodo {
	public partial class StartPage : PhoneApplicationPage {
		public StartPage() {
			InitializeComponent();
			InitializeCurrentTaskDisplay();
			initializeNextTaskDisplay();
		}

		private void InitializeCurrentTaskDisplay() {
			Event firstEvent = EventGiver.FirstEvent();
			if (firstEvent == null) {
				return;
			}

			TimeSpan breakDuration = firstEvent.StartTime - DateTime.Now;
			if (breakDuration.TotalMinutes <= 0) {
				// Dat is now. Wrong page.
				return;
			}
			else {
				// We has a break!
				String text = "";

				if (breakDuration.TotalMinutes >= 60) {
					// Long long break.
					text = "until " + firstEvent.StartTime.Hour + ":";
					if (firstEvent.StartTime.Minute < 10) {
						text += "0";
					}
					text += firstEvent.StartTime.Minute;
				}
				else {
					// Less than 60 minutes break
					text = "for " + breakDuration.Minutes + " minutes";
				}

				CurrentEventDuration.Text = text;
			}
		}

		private void initializeNextTaskDisplay() {
			Event firstEvent = EventGiver.FirstEvent();
			if (firstEvent == null) {
				return;
			}

			NextUpEventName.Text = firstEvent.Name;
			
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

		private void TapNext(object sender, System.Windows.Input.GestureEventArgs e) {
			NextUpEvent.Background = (Brush)this.Resources["PhoneDisabledBrush"];

			NextUpPanel.Visibility = System.Windows.Visibility.Visible;
		}

		private void AddButtonClick(object sender, System.EventArgs e) {
			NavigationService.Navigate(new Uri("/Adding.xaml", UriKind.Relative));
		}

		private void WhatDidYouDoTap(object sender, System.Windows.Input.GestureEventArgs e) {
			NavigationService.Navigate(new Uri("/IsDone.xaml", UriKind.Relative));
		}

		private void NextUpFocus(object sender, System.Windows.RoutedEventArgs e) {
			NextUpEvent.BorderBrush = (Brush)this.Resources["PhoneAccentColor"];
		}

		private void DoNextClicked(object sender, System.EventArgs e) {
			EventGiver.DoNext();
			EventGiver.NavigateToCorrectView(this);
		}
	}
}