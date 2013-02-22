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
	}
}