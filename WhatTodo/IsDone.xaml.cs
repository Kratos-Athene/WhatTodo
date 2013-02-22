using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WhatTodo {
	public partial class WhatDone : PhoneApplicationPage {
		IsDoneEvent e1 = new IsDoneEvent {
			Name = "Do the dishes",
			TimeString = "13.54, yesterday",
			OriginalEvent = null,
			ElementName = "e1"
		};
		IsDoneEvent e2 = new IsDoneEvent {
			Name = "Marketing article review",
			TimeString = "20.00, yesterday",
			OriginalEvent = null,
			ElementName = "e2"
		};
		IsDoneEvent e3 = new IsDoneEvent {
			Name = "Code lika an animal",
			TimeString = "8.00, today",
			OriginalEvent = null,
			ElementName = "e3"
		};
		IsDoneEvent e4 = new IsDoneEvent {
			Name = "Do the dishes",
			TimeString = "14.00, today",
			OriginalEvent = null,
			ElementName = "e4"
		};

		List<IsDoneEvent> IsDoneEvents;

		public WhatDone() {
			InitializeComponent();

			IsDoneEvents = new List<IsDoneEvent> { e1, e2, e3, e4 };
			IsDoneList.ItemsSource = IsDoneEvents;
		}

		public class IsDoneEvent {
			public string Name { get; set; }
			public string TimeString { get; set; }
			public int Number { get; set; }
			public string ElementName { get; set; }
			public Event OriginalEvent { get; set; }
			public bool Remove { get; set; }
		}

		private void AcceptDone(object sender, RoutedEventArgs e) {
			
			List<Event> eventsToRemove = new List<Event>();
			IsDoneEvents.ForEach(delegate(IsDoneEvent isDone) {
				CheckBox checkBox = IsDoneList.FindName(isDone.ElementName) as CheckBox;
				if (checkBox.IsChecked.Equals(true)) {
					eventsToRemove.Add(isDone.OriginalEvent);
				}
			});
		}

		private void AllCheckBoxClicked(object sender, RoutedEventArgs e) {
			if (AllCheckBox.IsChecked.Value) {
				IsDoneEvents.ForEach(delegate(IsDoneEvent isDone) {
					isDone.Remove = true;
				});
			}
		}


	}
}