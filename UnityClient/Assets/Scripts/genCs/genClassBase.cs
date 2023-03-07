//-----------------------------------------
// Auto Generated
//-----------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
#if UNITY_2021_3_OR_NEWER
using System.Linq;
#endif
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Data
{

	public enum ClassId : Int32
	{
		None = 0,
		novice = 1,
		traveler = 2,
	}


	[StructLayout(LayoutKind.Sequential)]
#if NET5_0_OR_GREATER
	[SkipLocalsInit]
#endif
	public struct ClassBase
	{
		public readonly UInt32 id;
		public readonly Int32 classid;
		public readonly Int32 hp;
		public readonly Int32 damage;
		public readonly String desc;
		public ClassBase(object[] param)
		{
			this.id = (UInt32)param[0];
			this.classid = (Int32)param[1];
			this.hp = (Int32)param[2];
			this.damage = (Int32)param[3];
			this.desc = (String)param[4];
		}
	}


	public class ClassBaseTable
	{
		protected Dictionary<System.UInt32, ClassBase> ClassBases = new ();
		protected Dictionary<string, Type> types = new ();

		public List<ClassBase> ClassBaseList { get => ClassBases.Values.ToList(); }
		public bool HasKey(System.UInt32 id) => ClassBases.ContainsKey(id);
		public ClassBase this[System.UInt32 id] => ClassBases[id];
		public int Count {get; set; }

		public virtual void Load(string path)
		{
			TypeFunc();
			var table = ConvertCSVtoDataTable(path);
			var rows = table.Rows;
			Count = rows.Count;
			for (int i = 0; i < Count; ++i)
			{
				ClassBase t = new ClassBase(rows[i].ItemArray);
				ClassBases.Add(t.id, t);
			}
		}

		void TypeFunc()
		{
			types["id"] = typeof(UInt32);
			types["classid"] = typeof(Int32);
			types["hp"] = typeof(Int32);
			types["damage"] = typeof(Int32);
			types["desc"] = typeof(String);
		}


		DataTable ConvertCSVtoDataTable(string strFilePath)
		{
			DataTable dt = new DataTable();
			using (StreamReader sr = new StreamReader(strFilePath))
			{
				string[] headers = sr.ReadLine().Split(',');
				for(int i = 0; i < headers.Length; ++i)
				{
#if UNITY_2021_3_OR_NEWER || CLIENT
					//client only
					dt.Columns.Add(headers[i].Split(':')[0], types[headers[i].Split(':')[0]]);
#else
					//exclude client only
					if (headers[i].Split(':').Length > 1)
						continue;
					dt.Columns.Add(headers[i], types[headers[i]]);
#endif
				}

				while(!sr.EndOfStream)
				{
					int typeIndex = 0;
					string[] rows = sr.ReadLine().Split(',');
					DataRow dr = dt.NewRow();
					for (int i = 0; i < headers.Length; i++)
					{
#if UNITY_2021_3_OR_NEWER || CLIENT
#else
						//exclude client only
						if (headers[i].Split(':').Length > 1)
							continue;
#endif
						dr[typeIndex] = TableData.ConvertTypes(types[headers[i].Split(':')[0]].Name, rows[i]);
						typeIndex++;
					}
					dt.Rows.Add(dr);
				}
			}
			return dt;
		}
	}
}
