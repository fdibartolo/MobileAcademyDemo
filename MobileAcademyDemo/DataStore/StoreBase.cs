using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;

namespace MobileAcademyDemo
{
	public abstract class StoreBase<T>
	{
		protected string storePath;
		protected DataContractSerializer serializer;

		public List<T> Read(){
			var result = new List<T>();
			
			using (var dict = XmlDictionaryReader.CreateDictionaryReader(
			                                 new XmlTextReader(
			                                 new FileStream(storePath, FileMode.OpenOrCreate)
			       ))){
			
				try {
					var obj = serializer.ReadObject(dict);

					foreach (var r in ((Array)obj)){
						result.Add((T)r);
					}
					return result;
				} catch {}
			}
			return result;
		}
		
		public void Save(List<T> data){
			using (var filestream = new FileStream(storePath, FileMode.Create)){
	            using(XmlWriter writer = XmlWriter.Create(filestream))
	            {
	                serializer.WriteObject(writer, data.ToArray());
	            }
			}
		}
	}
}



