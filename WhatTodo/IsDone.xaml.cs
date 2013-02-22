using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;

namespace WhatTodo {
	public partial class WhatDone : PhoneApplicationPage {

		List<IsDoneEvent> IsDoneEvents;

		public WhatDone() {
			InitializeComponent();
			InitializeListItems();
		}

		public class IsDoneEvent {
			public string Name { get; set; }
			public string TimeString { get; set; }
			public int Number { get; set; }
			public string ElementName { get; set; }
			public Event OriginalEvent { get; set; }
			public bool Remove { get; set; }
		}

		public void InitializeListItems() {
			List<Event> events = EventGiver.GetEvents();
			List<CheckBox> checkBoxes = new List<CheckBox>();
			checkBoxes.Add(e1);
			checkBoxes.Add(e2);
			checkBoxes.Add(e3);
			checkBoxes.Add(e4);

			int index = 0;
			foreach (Event e in events) {
				if (e == null) {
					continue;
				}
				if ((DateTime.Now - e.EndTime).TotalSeconds >= 0) {
					// Don't show old events
					checkBoxes.ElementAt(index).Visibility = System.Windows.Visibility.Collapsed;
				}
				index++;
			}
		}

		private void AcceptDone(object sender, RoutedEventArgs e) {
			List<Event> events = EventGiver.GetEvents();
			if (e1.IsChecked == true && events.ElementAt(0) != null) {
				events[0] = null;
			}
			if (e2.IsChecked == true && events.ElementAt(1) != null) {
				events[1] = null;
			}
			if (e3.IsChecked == true && events.ElementAt(2) != null) {
				events[2] = null;
			}
			if (e4.IsChecked == true && events.ElementAt(3) != null) {
				events[3] = null;
			}
				
			EventGiver.NavigateToCorrectView(this);
		}

		private void AllCheckBoxClicked(object sender, RoutedEventArgs e) {
			if (AllCheckBox.IsChecked.Value) {
				((CheckBox)e1).IsChecked = true;
				((CheckBox)e2).IsChecked = true;
				((CheckBox)e3).IsChecked = true;
				((CheckBox)e4).IsChecked = true;
			}
			else {
				((CheckBox)e1).IsChecked = false;
				((CheckBox)e2).IsChecked = false;
				((CheckBox)e3).IsChecked = false;
				((CheckBox)e4).IsChecked = false;
			}
		}


	}
}