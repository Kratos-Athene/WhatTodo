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

		public int GetTimeInstant(int Minutes) {
			int MinuteWork = Minutes;
			foreach (Time t in Times) {
				MinuteWork = MinuteWork - t.Span.Minutes;
				if (MinuteWork == 0) {
					return Times.IndexOf(t);
				}
				else if (MinuteWork < 0) {
					return Halfen(Times.IndexOf(t), MinuteWork);
				}
			}
		}

		private int Halfen(int Index, int HalfingPoint) {
			Time Halfable = Times(Index);

		}

		class Time {
			public TimeSpan Span { get; set; }
			public Priority Priority { get; set; }
		}
	}
}
