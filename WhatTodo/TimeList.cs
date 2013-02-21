using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	class TimeList {
		public List<Time> Times { get; set; }

		public TimeList(List<Event> ListOfEvents) {
			Times = new List<Time>();
			foreach (Event e in ListOfEvents) {
				Time NewTime = new Time();
				NewTime.Priority = e.Priority;

			}
		}

		class Time {
			public TimeSpan Span { get; set; }
			public Priority Priority { get; set; }
		}
	}
}
