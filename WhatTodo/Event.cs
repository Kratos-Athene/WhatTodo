using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	public class Event {
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public Priority Priority { get; set; }
	}
}
