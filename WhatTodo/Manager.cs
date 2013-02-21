using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	class Manager {
		public UI UI { get; set; }
		public TodoList TodoList { get; set; }
		private List<Event> UserEvents;
		private WPCal Cal;
		private Algo Algo;

		public Manager(WhatTodo.UI ui, WhatTodo.TodoList todoList) {
			UI = ui;
			TodoList = todoList;
		}

		public void ReCalc() {
			Cal = new WPCal(UserEventsLoaded);
		}

		private void UserEventsLoaded() {
			UserEvents = Cal.Events;
			Algo = new Algo(UserEvents,TodoList,AlgoRecalcReady);
		}

		private void AlgoRecalcReady() {
			UI.UpdateUI();
		}



	}
}
