using Microsoft.Phone.UserData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WhatTodo
{
	public class WPCal
	{
		private Action Callback;
		private bool Error;
		public List<Event> Events { get; set; }

		public WPCal(Action pCallback)
		{
			Callback = pCallback;
		}

		public void LoadUserEvents()
		{
			LoadAppointments();
		}

		private void LoadAppointments()
		{
			Appointments appoints = new Appointments();

			appoints.SearchCompleted += appoints_SearchCompleted;

			DateTime now = DateTime.Now;
			DateTime end = now.AddYears(1);

			appoints.SearchAsync(now, end, "Get all appointments for WhatTodo");
		}

		private void appoints_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
		{
			IEnumerable<Event> appointEnumerable = from appoint in e.Results
											 select new Event {
												StartTime = appoint.StartTime,
												EndTime = appoint.EndTime,
												Name = appoint.Subject
											 };

			Events = appointEnumerable.ToList<Event>();

			Debug.WriteLine("events loaded, " + Events.Count);
			Callback.Invoke();
		}

	}
}
