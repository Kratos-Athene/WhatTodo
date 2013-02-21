using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo {
	class TodoList {
		private List<TodoEvent> Todos { get; set; }

		public TodoList() {
			Todos = new List<TodoEvent>();
		}

		/**
		 * Method for adding a TodoEvent to TodoList into the list. 
		 */
		public void AddTodo(String pName, TimeSpan pRequired, Priority pPriority, DateTime pDeadline, string pInfo, Boolean pSplit) {
			TodoEvent NewTodo = new TodoEvent();
			NewTodo.Name = pName;
			NewTodo.Required = pRequired;
			NewTodo.Priority = pPriority;
			NewTodo.Deadline = pDeadline;
			NewTodo.Info = pInfo;
			NewTodo.Split = pSplit;

			Todos.Add(NewTodo);
		}

		/**
		 * 
		 */
	}
}
