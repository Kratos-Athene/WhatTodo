using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	public enum Priority {
		ASAP,
		DL,
		LAZY,
		CAL,
		FREE
	}
	public class TodoEvent {
		public string Name { get; set; }
		public Priority Priority { get; set; }
		public TimeSpan Required { get; set; }
		public DateTime Deadline { get; set; }
		public string Info { get; set; }
		public Boolean Split { get; set; }

		public int GetTimeToDeadline() {
			DateTime Current = DateTime.Now;

			TimeSpan Difference = Deadline - Current;

			return (int) Difference.TotalMinutes;
		}
	}
}
