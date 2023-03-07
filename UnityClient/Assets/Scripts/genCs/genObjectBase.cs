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


	[StructLayout(LayoutKind.Sequential)]
#if NET5_0_OR_GREATER
	[SkipLocalsInit]
#endif
	public struct ObjectBase
	{
		public readonly Int32 id;
		public readonly Int64 max_hp;
		public readonly Int64 damage;
		public readonly Int64 exp;
		public readonly UInt32[] drop_table;
		public readonly String name;
		public readonly String resource;
		public ObjectBase(object[] param)
		{
			this.id = (Int32)param[0];
			this.max_hp = (Int64)param[1];
			this.damage = (Int64)param[2];
			this.exp = (Int64)param[3];
			this.drop_table = (UInt32[])param[4];
			this.name = (String)param[5];
			this.resource = (String)param[6];
		}
	}


	public class ObjectBaseTable
	{
		protected Dictionary<System.Int32, ObjectBase> ObjectBases = new ();
		protected Dictionary<string, Type> types = new ();

		public List<ObjectBase> ObjectBaseList { get => ObjectBases.Values.ToList(); }
		public bool HasKey(System.Int32 id) => ObjectBases.ContainsKey(id);
		public ObjectBase this[System.Int32 id] => ObjectBases[id];
		public int Count {get; set; }

		public virtual void Load(string path)
		{
			TypeFunc();
			var table = ConvertCSVtoDataTable(path);
			var rows = table.Rows;
			Count = rows.Count;
			for (int i = 0; i < Count; ++i)
			{
				ObjectBase t = new ObjectBase(rows[i].ItemArray);
				ObjectBases.Add(t.id, t);
			}
		}

		void TypeFunc()
		{
			types["id"] = typeof(Int32);
			types["max_hp"] = typeof(Int64);
			types["damage"] = typeof(Int64);
			types["exp"] = typeof(Int64);
			types["drop_table"] = typeof(UInt32[]);
			types["name"] = typeof(String);
			types["resource"] = typeof(String);
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
