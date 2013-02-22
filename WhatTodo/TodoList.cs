using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO.IsolatedStorage;
using System.IO;

namespace WhatTodo {
	public class TodoList {
		static string TODO_FILE = "Todos.xml";
		public List<TodoEvent> Todos { get; set; }

		public TodoList() {
			Todos = LoadTodos();
		}

		/**
		 * Method for adding a TodoEvent to TodoList into the list. 
		 */
		public Boolean AddTodo(String pName, TimeSpan pRequired, Priority pPriority, DateTime pDeadline, string pInfo, Boolean pSplit) {
			TodoEvent NewTodo = new TodoEvent();
			NewTodo.Name = pName;
			NewTodo.Required = pRequired;
			NewTodo.Priority = pPriority;
			NewTodo.Deadline = pDeadline;
			NewTodo.Info = pInfo;
			NewTodo.Split = pSplit;

			Todos.Add(NewTodo);
			return SaveTodos();
		}

		/**
		 * Method for getting the total duration of Todos.
		 */
		public int GetTotalDuration() {
			int Duration = 0;
			foreach (TodoEvent e in Todos) {
				Duration += (int) e.Required.TotalMinutes;
			}
			return Duration;
		}

		private Boolean SaveTodos() {
			try {
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.Indent = true;

				using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication()) {
					using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile(TODO_FILE, FileMode.Create, FileAccess.Write)) {
						XmlSerializer serializer = new XmlSerializer(typeof(List<TodoEvent>));
						using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings)) {
							serializer.Serialize(xmlWriter, Todos);
						}
					}
				}
				return true;
			}
			catch {
				return false;
			}
		}

		private List<TodoEvent> LoadTodos() {
			List<TodoEvent> pTodos = new List<TodoEvent>();

			try {
				using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication()) {
					using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile(TODO_FILE, FileMode.Open)) {
						XmlSerializer serializer = new XmlSerializer(typeof(List<TodoEvent>));
						pTodos = (List<TodoEvent>)serializer.Deserialize(stream);
					}
				}
			}
			catch {

			}

			return pTodos;
		}
	} // End of class TodoList.
}
