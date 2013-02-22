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

namespace WhatTodo {
	public partial class MainPage : PhoneApplicationPage {
		WPCal cal;

		// Constructor
		public MainPage() {
			InitializeComponent();

			UI ui = new UI(this);
			TodoList todoList = new TodoList();

			//Manager manager = new Manager(ui,todoList);

			ui.TodoList = todoList;

			// jubis testing WPCal
			cal = new WPCal(TestWPCal);
			cal.LoadUserEvents();

			Debug.WriteLine("starting");

			// SieniMaagi testing TodoList
			TestTodoList();
			TestTimeList();
		}

		
		/**
		 * Jubis testing WPCal
		 */

		void TestWPCal() {
			int i = 0;
			cal.Events.ForEach(delegate(Event testEvent) {
				if (i++ < 5) {
					TestEventContent(testEvent);
				}
			});
		}

		private void TestEventContent(Event testEvent) {
			Debug.WriteLine("'" + testEvent.Name + "'");
			Debug.WriteLine(testEvent.StartTime);
			Debug.WriteLine(testEvent.EndTime);
		}

		/*
		 * Testing ends
		 */

		/**
		 * SieniMaagi testing TodoList
		 */
		void TestTodoList() {
			TodoList List = new TodoList();

			List.AddTodo("Tiskaus", new TimeSpan(0, 60, 0), Priority.LAZY, new DateTime(2013, 3, 12), "", true);
			List.AddTodo("Sali", new TimeSpan(0, 60, 0), Priority.ASAP, new DateTime(), "", false);

			Debug.WriteLine(List.GetTotalDuration());

		}

		void TestTimeList() {
			List<Event> ListOfEvents = new List<Event>();
			Event Event1 = new Event();
			Event Event2 = new Event();
			Event1.Name = "Tiskaus";
			Event2.Name = "Sali";
			Event1.StartTime = new DateTime(2013, 3, 12, 11, 0, 0);
			Event1.EndTime = new DateTime(2013, 3, 12, 12, 0, 0);
			Event2.StartTime = new DateTime(2013, 3, 12, 14, 0, 0);
			Event2.EndTime = new DateTime(2013, 3, 12, 14, 30, 0);

			ListOfEvents.Add(Event1);
			ListOfEvents.Add(Event2);

			TimeList ListOfTimes = new TimeList(ListOfEvents);

			Debug.WriteLine(ListOfTimes.GetTimeIndex(60));
			Debug.WriteLine(ListOfTimes.GetTimeIndex(90));
			Debug.WriteLine(ListOfTimes.GetTimeIndex(75));
		}
		/*
		 * End of SieniMaagi's testing
		 */
	}
}