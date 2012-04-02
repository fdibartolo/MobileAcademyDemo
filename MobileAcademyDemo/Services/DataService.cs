using System;
using System.Linq;
using System.Collections.Generic;

namespace MobileAcademyDemo
{
	public class DataService
	{
		private NotesStore _store;
		private static DataService _instance;
		private List<Note> _notes;
		
		public DataService (NotesStore store) {
			_store = store;
			_notes = _store.Read();
			_instance = this;
		}
		
		public static DataService GetInstance { get { return _instance; } }
		
		public List<Note> LoadNotes() {
			return _notes;
		}
		
		public void SaveNote(Note note) {
			_notes.Add(note);
			_store.Save(_notes);
		}
	}
}

