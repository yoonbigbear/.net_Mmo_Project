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
	public struct Craft
	{
		public readonly Int32 id;
		public readonly UInt32[] ingredients;
		public readonly Int32[] counts;
		public readonly String resource;
		public Craft(object[] param)
		{
			this.id = (Int32)param[0];
			this.ingredients = (UInt32[])param[1];
			this.counts = (Int32[])param[2];
			this.resource = (String)param[3];
		}
	}


	public class CraftTable
	{
		protected Dictionary<System.Int32, Craft> Crafts = new ();
		protected Dictionary<string, Type> types = new ();

		public List<Craft> CraftList { get => Crafts.Values.ToList(); }
		public bool HasKey(System.Int32 id) => Crafts.ContainsKey(id);
		public Craft this[System.Int32 id] => Crafts[id];
		public int Count {get; set; }

		public virtual void Load(string path)
		{
			TypeFunc();
			var table = ConvertCSVtoDataTable(path);
			var rows = table.Rows;
			Count = rows.Count;
			for (int i = 0; i < Count; ++i)
			{
				Craft t = new Craft(rows[i].ItemArray);
				Crafts.Add(t.id, t);
			}
		}

		void TypeFunc()
		{
			types["id"] = typeof(Int32);
			types["ingredients"] = typeof(UInt32[]);
			types["counts"] = typeof(Int32[]);
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
