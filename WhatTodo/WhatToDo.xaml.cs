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

namespace WhatTodo {
	public partial class StartPage : PhoneApplicationPage {
		public StartPage() {
			InitializeComponent();
		}

		private void TapNext(object sender, System.Windows.Input.GestureEventArgs e) {
			NextUpEvent.Background = (Brush)this.Resources["PhoneDisabledBrush"];

			NextUpPanel.Visibility = System.Windows.Visibility.Visible;
		}

		private void AddButtonClick(object sender, System.EventArgs e) {
			NavigationService.Navigate(new Uri("/Adding.xaml", UriKind.Relative));
		}

		private void WhatDidYouDoTap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			NavigationService.Navigate(new Uri("/IsDone.xaml", UriKind.Relative));
		}

		private void NextUpFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			NextUpEvent.BorderBrush = (Brush) this.Resources["PhoneAccentColor"];
		}
	}
}