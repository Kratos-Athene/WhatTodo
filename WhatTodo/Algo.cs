using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	public class Algo {
		public int indexASAP, indexDL, indexLazy = 0;

		public List<TodoEvent> sortedASAP;
		public List<TodoEvent> sortedDL;
		public List<TodoEvent> sortedLazy;
		//public List<TodoEvent> sortedLazySplit;

		public TodoList todolist;
		public TimeList timelist;

		public Algo(List<Event> pEventList, TodoList pTodoList, Action pCallback) {

			//aikaa_kaikelle = kuinka paljon aikaa tarvitaan kaikkien listassa olevien toteutukseen
			todolist = pTodoList;

			PopulateSorting();

			//tee timelist
			timelist = new TimeList(pEventList);

			// OPERATE
			// NOW => PANIC
			TodoEvent now = GetNextASAP();
			while (now != null) {
				Panic(now);
				now = GetNextASAP();
			}

			//for DL in DLs
			TodoEvent dl = GetNextDL();
			while (dl != null) {
				//	timeRqd = DL.Duration() * 3/2
				int time_required = (int)dl.Required.TotalMinutes;
				//	counter = timeRqd * 2
				int counter = time_required * 2;

				// deadlinen index, puolitettu tarvittaessa
				int end_index = timelist.GetTimeIndex(dl.GetTimeToDeadline());

				// start_index iteroidaan alaspäin
				int start_index = end_index - 1;
				// kuinka paljon tultiin alaspäin
				int duration = 0;

				while (start_index > 0) {
					TimeList.Time element = timelist.GetElement(start_index);
					// lisätään jokatapauksessa duration
					duration += (int)element.Span.TotalMinutes;
					// jos saadaan lisää tyhjää aikaa
					if (element.Priority == Priority.FREE) {
						counter -= (int)element.Span.TotalMinutes;
					}
					// jos tultiin tarpeeksi pitkälle
					if (counter < 0) {
						duration += counter;
						int start_instance = dl.GetTimeToDeadline() - duration;
						start_index = timelist.GetTimeIndex(start_instance);
					}
				}
				if (timelist.GetTimeBetween(start_index, end_index) < time_required) {
					Panic(dl);
				}
				TimeList list_dl = CropAndSort(start_index, end_index, timelist);
				Position(dl, list_dl);

				dl = GetNextDL();
			} // LOOP WHILE THERE IS DL


			// sijoita ensin continuous
			foreach (TodoEvent te in sortedLazy) {
				if (!te.Split) {
					Position(te, timelist);
				}
			}
			// sijoita sitten jaettavat
			foreach (TodoEvent te in sortedLazy) {
				if (te.Split) {
					Position(te, timelist);
				}
			}

			pCallback.Invoke();
		}

		public void PopulateSorting() {
			indexASAP = 0;
			indexDL = 0;
			indexLazy = 0;

			foreach (TodoEvent te in todolist.Todos) {
				if (te.Priority == Priority.ASAP)
					sortedASAP.Add(te);
				else if (te.Priority == Priority.DL)
					sortedDL.Add(te);
				else if (te.Priority == Priority.LAZY)
					sortedLazy.Add(te);
			}
			// TODO FIRST
			//sortedDL.Sort(delegate(Person p1, Person p2) { return p1.name.CompareTo(p2.name); });
			sortedDL.Sort(delegate(TodoEvent te1, TodoEvent te2) {
				return te1.Deadline.CompareTo(te2.Deadline);
			});
		}

		//int CalculateTime(DateTime now, DateTime then) {
		// LASKE EROTUS PALAUTA MINUUTTEINA
		//}


		public TodoEvent GetNextASAP() {
			if (indexASAP < sortedASAP.Count) {
				TodoEvent te = sortedASAP.ElementAt(indexASAP);
				indexASAP++;
				return te;
			}
			return null;
		}

		public TodoEvent GetNextDL() {
			if (indexDL < sortedDL.Count) {
				TodoEvent te = sortedDL.ElementAt(indexDL);
				indexDL++;
				return te;
			}
			return null;
		}

		public TodoEvent GetNextLazy() {
			if (indexLazy < sortedLazy.Count) {
				TodoEvent te = sortedLazy.ElementAt(indexLazy);
				indexLazy++;
				return te;
			}
			return null;
		}

		// position as ASAP
		public void Panic(TodoEvent te) {
			int dur = (int)te.Required.TotalMinutes;

			int i = 0;
			// CONTINUOUS
			if (te.Split) {
				while (i < timelist.GetSize()) {
					TimeList.Time t = timelist.GetElement(i);
					if ((int)t.Span.TotalMinutes >= dur) {
						timelist.InsertElement(i, dur, Priority.ASAP);
					}
				}
			}

			// SPLITABLE
			else {
				int remaining = dur;
				while ((remaining = timelist.InsertElement(i, remaining, Priority.ASAP)) > 0) {
					i++;
					while (i < timelist.GetSize()) {
						if (timelist.GetElement(i).Priority == Priority.FREE) {
							break;
						}
						else {
							i++;
						}
					} // while etsi uusi
				} // on vielä lisättävää
			} // SPLITABLE
		}

		public TimeList CropAndSort(int start, int end, TimeList list) {
			List<TimeList.Time> new_list = timelist.Times.GetRange(start, end - start);

			// SORT
			new_list.Sort(delegate(TimeList.Time t1, TimeList.Time t2) {
				return (t1.Span.CompareTo((int)t2.Span.TotalMinutes));
			});
			TimeList tl = new TimeList(new_list);
			return tl;
		}

		public void Position(TodoEvent te, TimeList list) {

			int dur = (int)te.Required.TotalMinutes;
			int i = 0;

			int remaining = dur;
			while ((remaining = timelist.InsertElement(i, remaining, Priority.ASAP)) > 0) {
				i++;
				while (i < list.GetSize()) {
					if (timelist.GetElement(i).Priority == Priority.FREE) {
						break;
					}
					else {
						i++;
					}
				} // while etsi uusi
			} // on vielä lisättävää
		} // end of Position
	} // end of class
} // end of namespace
