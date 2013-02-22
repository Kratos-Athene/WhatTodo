using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	public static class EventGiver {
		public static List<Event> ListOfEvents = new List<Event>();
		public static Boolean Initialized = false;

		public static void Init() {
			Event CurrentEvent = new Event();
			CurrentEvent.StartTime = new DateTime(2013, 2, 22, 13, 0, 0);
			CurrentEvent.EndTime = new DateTime(2013, 2, 22, 20, 30, 0);
			CurrentEvent.Name = "Do the dishes";
			CurrentEvent.Priority = Priority.ASAP;
			CurrentEvent.Info = "You've procrastinated for much too long, it's time to give those dishes a proper cleaning!";
			ListOfEvents.Add(CurrentEvent);

			Event NextEvent = new Event();
			NextEvent.StartTime = new DateTime(2013, 2, 23, 12, 0, 0);
			NextEvent.EndTime = new DateTime(2013, 2, 23, 13, 0, 0);
			NextEvent.Name = "Go to the gym";
			NextEvent.Priority = Priority.LAZY;
			NextEvent.Info = "Gotta work on those biceps and femurs, if you want to be on the defensive line next season!";
			ListOfEvents.Add(NextEvent);

			Event ThirdEvent = new Event();
			ThirdEvent.StartTime = new DateTime(2013, 2, 25, 16, 0, 0);
			ThirdEvent.EndTime = new DateTime(2013, 2, 25, 18, 0, 0);
			ThirdEvent.Name = "That project ain't going to do itself 1/3";
			ThirdEvent.Priority = Priority.DL;
			ThirdEvent.Info = "Need to finish that customer project by the end of february!";
			ListOfEvents.Add(ThirdEvent);

			Event FourthEvent = new Event();
			FourthEvent.StartTime = new DateTime(2013, 2, 26, 14, 0, 0);
			FourthEvent.EndTime = new DateTime(2013, 2, 26, 16, 0, 0);
			FourthEvent.Name = "That project ain't going to do itself 2/3";
			FourthEvent.Priority = Priority.DL;
			FourthEvent.Info = "Need to finish that customer project by the end of february!";
			ListOfEvents.Add(FourthEvent);

			Event FifthEvent = new Event();
			FifthEvent.StartTime = new DateTime(2013, 2, 28, 15, 0, 0);
			FifthEvent.EndTime = new DateTime(2013, 2, 28, 17, 0, 0);
			FifthEvent.Name = "That project ain't going to do itself 3/3";
			FifthEvent.Priority = Priority.DL;
			FifthEvent.Info = "Need to finish that customer project by the end of february!";
			ListOfEvents.Add(FifthEvent);
		}

		public static List<Event> GetEvents() {
			if (!Initialized) {
				Init();
				Initialized = true;
			}
			return ListOfEvents;
		}

		public static void TakeABreak() {
			foreach (Event e in ListOfEvents) {
				e.StartTime.AddMinutes(30);
				e.EndTime.AddMinutes(30);
			}
		}

		public static void DoNext() {
			try {
			Event Next = ListOfEvents.ElementAt(0);
			TimeSpan Duration = Next.EndTime - Next.StartTime;
			Next.StartTime = DateTime.Now;
			Next.EndTime = DateTime.Now + Duration;
			} catch {
			
			}
		}
	}
}
