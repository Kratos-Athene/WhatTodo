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
				NewTime.Span = e.EndTime - e.StartTime;
				Times.Add(NewTime);
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
			return Times.Count--;
		}

		private int Halfen(int Index, int HalfingPoint) {
			Time Halfable = Times(Index);
			Time FirstHalf = new Time();
			Time SecondHalf = new Time();

			FirstHalf.Span = Halfable.Span.Subtract(new Time(0, Math.Abs(HalfingPoint), 0));
			FirstHalf.Priority = Priority.FREE;

			SecondHalf.Span = Halfable.Span.Subtract(FirstHalf.Span);
			SecondHalf.Priority = Priority.FREE;

			Times.Insert(Index, FirstHalf);
			Times.Insert(Index++, SecondHalf);

			return Index++;
		}

		class Time {
			public TimeSpan Span { get; set; }
			public Priority Priority { get; set; }
		}
	}
}
