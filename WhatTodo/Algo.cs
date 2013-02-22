using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	class Algo {

	public Algo(List<Event> eventlist, TodoList todolist, Action callback) {

		/*//aikaa_kaikelle = kuinka paljon aikaa tarvitaan kaikkien listassa olevien toteutukseen
		List<TodoEvent> list_todoevent  = todolist.GetTodos();

		int time_needed = list_todoevent.GetTotalDuration();
		int time_needed_pad = time_needed * 3 / 2;
		int endtime = time_needed_pad;*/
		//if (endtime < list_todoevent.

//aikaa_padded = aikaa_kaikelle * 3/2
//loppuaika = aikaa_padded
//if loppuaika < kesto kauimmaiseen
//	loppuaika = kesto_kauimmaiseen

//tee timespanlist

// aloita operaatio

//Onko NOW?
//PANIC

//for DL in DLs
//	timeRqd = DL.Duration() * 3/2
//	counter = timeRqd * 2
//	etsi DL sijainti
//	jos deadline ei ole timespansaumassa, jaa elementti
//		ota taaksepäin seuraava elementti joka on vapaata aikaa:
//			elemlen = elementin pituus
//			counter -= elemlen
			
//			if counter<0, saavutettiin optimipiste, sauma kohtaan (-elemlen)
//				jos ei saumassa, tee sauma
//				alkupiste = viittaus ensimmäiseen timespanniin
				
//		jos ollaan elementissä 0
//			alkupiste = elementti 0
	
//jos kesto alkupisteestä deadlineen on alle timeRqd, PANIC
//	sijoita DL määrätylle jaksolle


//sijoita ensin continous, isoin ensin
//for LAZY in LAZYS
//	sijoita LAZY


//SIJOITUS, jos DL, annetaan myös etu ja takaraja
//jos cont
//	aikalistaus 24h tuntia
//sijoita isoimpaan väliin
//jos ei mahdu, etsi ensimmäinen paikka johon mahtuu 
//else
//	sijoita välille pienimpiin väleihin, eli merkkaa välejä käytetyksi,
//jos DL, käytä vain tiettyyn asti
		}

	//private void position() {}

	}
}
