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
			if (note.Id == null) {
				var maxId = _notes.Select(n => n.Id).Max() ?? 0;
				note.Id = maxId + 1;
				_notes.Add(note);
			}
			else {
				var updatedNote = (from n in _notes where (n.Id == note.Id) select n).Single();
				updatedNote.Name = note.Name;
				updatedNote.Body = note.Body;
			}
			_store.Save(_notes);
		}
		
		public Note FindNoteByName(string name) {
			return _notes.Where(n => n.Name.Equals(name)).Single();	
		}
	}
}

