using System;
using System.Runtime.Serialization;
using System.IO;

namespace MobileAcademyDemo
{
	public class NotesStore : StoreBase<Note>
	{
		public NotesStore() {
			storePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "notes.xml");
			serializer = new DataContractSerializer(typeof(Note[]));
		}
	}
}


