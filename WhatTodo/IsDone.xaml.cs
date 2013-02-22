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