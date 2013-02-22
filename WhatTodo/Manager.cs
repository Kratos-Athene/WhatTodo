using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO.IsolatedStorage;
using System.IO;

namespace WhatTodo {
	class Manager {
		public UI UI { get; set; }
		public TodoList TodoList { get; set; }
		private List<Event> UserEvents;
		private WPCal Cal;
		private Algo Algo;
		/*
		static string UserFile = "Event_file.xml";
		public List<Event> PastEvents;*/

		public Manager(WhatTodo.UI ui, WhatTodo.TodoList todoList) {
			UI = ui;
			TodoList = todoList;
		}

		public void ReCalc() {
			Cal = new WPCal(UserEventsLoaded);
			Cal.LoadUserEvents();
		}

		private void UserEventsLoaded() {
			UserEvents = Cal.Events;
			//Algo = new Algo(UserEvents,TodoList, DateTime.Now, AlgoRecalcReady);
		}

		private void AlgoRecalcReady() {
			UI.UpdateUI();
		}

		/*private void SaveFile() {

		}

		private void LoadFile() {
			List<Event> pEvent = new List<Event>();

			try {
				using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication()) {
					using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile(TODO_FILE, FileMode.Open)) {
						XmlSerializer serializer = new XmlSerializer(typeof(List<TodoEvent>));
						pTodos = (List<TodoEvent>)serializer.Deserialize(stream);
					}
				}
			}
			catch {

			}

			UserEvents = pEvent;
		} */
	}
}
