using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	class Algo {
		public:
		int indexASAP, indexDL, indexLazy = 0;

		List<TodoEvent> sortedASAP;
		List<TodoEvent> sortedDL;
		List<TodoEvent> sortedLazy;

		TodoList todolist;

		public Algo(List<Event> pEventList, TodoList pTodoList, DateTime pNow, Action pCallback) {

			//aikaa_kaikelle = kuinka paljon aikaa tarvitaan kaikkien listassa olevien toteutukseen
			todolist = pTodoList;

			PopulateSorting();

			//tee timelist
			TimeList timelist = new TimeList(eventlist);

			// OPERATE
			// NOW => PANIC
			TodoEvent now = GetNextASAP();
			while ((now != null) {
				panic(now);
				now = GetNextASAP();
			}

			//for DL in DLs
			TodoEvent dl = GetNextDL();
			while (dl != null) {
				//	timeRqd = DL.Duration() * 3/2
				int time_required = dl.Required;
						//	counter = timeRqd * 2
				int counter = time_required * 2;

				

				// deadlinen index, puolitettu tarvittaessa
				int end_index = dl.GetTimeIndex(dl.GetTimeToDeadline());

				// start_index iteroidaan alaspäin
				int start_index = end_index-1;
				// kuinka paljon tultiin alaspäin
				int duration = 0;

				while (start_index>0) {
					Time element = timelist.GetElement();
					// lisätään jokatapauksessa duration
					duration += element.Duration();
					// jos saadaan lisää tyhjää aikaa
					if (element.GetPriority == FREE) {
						counter -= element.Duration();
					}
					// jos tultiin tarpeeksi pitkälle
					if (counter<0) {
						duration += counter;
						int start_instance = dl.GetTimeToDeadline() - duration;
						start_index = GetTimeIndex(start_instance);
					}
				}
				if (timelist.GetTimeBetween(start_index, end_index) < time_required) {
					panic(dl);
				}
				position(dl);
			}


			//sijoita ensin continous, isoin ensin
			//for LAZY in LAZYS
			//	sijoita LAZY
		}

		//SIJOITUS, jos DL, annetaan myös etu ja takaraja
		//jos cont
		//	aikalistaus 24h tuntia
		//sijoita isoimpaan väliin
		//jos ei mahdu, etsi ensimmäinen paikka johon mahtuu 
		//else
		//	sijoita välille pienimpiin väleihin, eli merkkaa välejä käytetyksi,
		//jos DL, käytä vain tiettyyn asti

		void PopulateSorting() {
			indexASAP = 0;
			indexDL = 0;
			indexLazy = 0;

			foreach (TodoEvent te in todolist.Todos)
			{
				if (te.GetEnum() == Priority.ASAP)
					sortedASAP.Add(te);
				else if (te.GetEnum() == Priority.DL)
					sortedDL.Add(te);
				else if (te.GetEnum() == Priority.LAZY)
					sortedLazy.Add(te);
			}
				// TODO SORTING!!!!
				// example:
				//sortedDL.Sort(delegate(Person p1, Person p2) { return p1.name.CompareTo(p2.name); });
		}

		//int CalculateTime(DateTime now, DateTime then) {
		// LASKE EROTUS PALAUTA MINUUTTEINA
		//}


		TodoEvent GetNextASAP() { }


		// position as ASAP
		void panic(TodoEvent te) { }
		// position typical
		void position(TodoEvent te) { }

	}
}
