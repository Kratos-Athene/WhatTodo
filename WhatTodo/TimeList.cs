using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	public class TimeList {
		public List<Time> Times { get; set; }

		public TimeList(List<Event> ListOfEvents) {
			Times = new List<Time>();
			foreach (Event e in ListOfEvents) {
				Time NewTime = new Time();
				NewTime.Priority = e.Priority;
				NewTime.Span = e.EndTime - e.StartTime;
				NewTime.Name = e.Name;
				NewTime.Info = e.Info;
				Times.Add(NewTime);
			}
		}

		public TimeList(List<Time> ListOfTimes) {
			Times = ListOfTimes;
		}

		public int GetTimeIndex(int Minutes) {
			int MinuteWork = Minutes;
			foreach (Time t in Times) {
				MinuteWork = MinuteWork - (int) t.Span.TotalMinutes;
				if (MinuteWork == 0) {
					return Times.IndexOf(t);
				}
				else if (MinuteWork < 0) {
					return Split(Times.IndexOf(t), MinuteWork);
				}
			}
			return Times.Count - 1;
		}

		public int Split(int Index, int HalfingPoint) {
			Time Halfable = Times.ElementAt(Index);
			Time FirstHalf = new Time();
			Time SecondHalf = new Time();

			FirstHalf = Time.CopyFrom(Math.Abs(HalfingPoint), Halfable);
			//FirstHalf.Span = Halfable.Span.Subtract(new TimeSpan(0, Math.Abs(HalfingPoint), 0));
			//FirstHalf.Priority = Priority.FREE;

			int dur = (int)Halfable.Span.Subtract(FirstHalf.Span).TotalMinutes;
			SecondHalf = Time.CopyFrom(dur, Halfable);
			//SecondHalf.Span = Halfable.Span.Subtract(FirstHalf.Span);
			//SecondHalf.Priority = Priority.FREE;

			Times.RemoveAt(Index);

			Times.Insert(Index, FirstHalf);
			Times.Insert(Index++, SecondHalf);

			return Index++;
		}

		public int GetTimeBetween(int StartIndex, int EndIndex) {
			int Minutes = 0;
			foreach (Time t in Times) {
				if (Times.IndexOf(t) > StartIndex && Times.IndexOf(t) < EndIndex) {
					Minutes += (int) t.Span.TotalMinutes;
				}
			}
			return Minutes;
		}

		public int InsertElement(int Index, int Minutes, Priority Priority) {
			Time UsableTime = Times.ElementAt(Index);

			// 
			if ((int)UsableTime.Span.TotalMinutes == Minutes) {
				UsableTime.Priority = Priority;
				Times.RemoveAt(Index);
				Times.Insert(Index, UsableTime);
				return 0;
			}
			else if ((int)UsableTime.Span.TotalMinutes < Minutes) {
				Time NewTime1 = new Time();
				Time NewTime2 = new Time();

				NewTime2.Span = new TimeSpan(0, (int)UsableTime.Span.TotalMinutes - Minutes, 0);
				NewTime1.Span = new TimeSpan(0, (int)UsableTime.Span.TotalMinutes - (int)UsableTime.Span.TotalMinutes, 0);
				NewTime2.Priority = Priority.FREE;
				NewTime1.Priority = Priority;

				Times.RemoveAt(Index);
				Times.Insert(Index, NewTime1);
				Times.Insert(Index++, NewTime2);
				return 0;
			}
			else {
				UsableTime.Priority = Priority;
				Times.RemoveAt(Index);
				Times.Insert(Index, UsableTime);
				return Minutes - (int) UsableTime.Span.TotalMinutes;
			}
		}

		public Time GetElement(int index) {
			return Times.ElementAt(index);
		}

		public int GetSize() {
			return Times.Count;
		}

		public class Time {
			public TimeSpan Span { get; set; }
			public Priority Priority { get; set; }
			public String Name { get; set; }
			public String Info { get; set; }
			public static Time CopyFrom(int duration, Time from) {
				Time t = new Time();
				t.Span = new TimeSpan(duration);
				t.Priority = from.Priority;
				t.Name = from.Name;
				t.Info = from.Info;
				return t;
			}
		}
	}
}
