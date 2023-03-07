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

	public enum Usage : Byte
	{
		None = 0,
		weapon = 1,
		defence = 2,
		consume = 3,
		accessory = 4,
		misc = 5,
	}

	public enum Level : Byte
	{
		None = 0,
		normal = 1,
		magic = 2,
		rare = 3,
		unique = 4,
		legend = 5,
	}


	[StructLayout(LayoutKind.Sequential)]
#if NET5_0_OR_GREATER
	[SkipLocalsInit]
#endif
	public struct Item
	{
		public readonly UInt32 id;
		public readonly Int32 maxstack;
		public readonly Byte level;
		public readonly Byte usage;
		public readonly String name;
		public readonly String resource;
		public readonly String desc;
		public Item(object[] param)
		{
			this.id = (UInt32)param[0];
			this.maxstack = (Int32)param[1];
			this.level = (Byte)param[2];
			this.usage = (Byte)param[3];
			this.name = (String)param[4];
			this.resource = (String)param[5];
			this.desc = (String)param[6];
		}
	}


	public class ItemTable
	{
		protected Dictionary<System.UInt32, Item> Items = new ();
		protected Dictionary<string, Type> types = new ();

		public List<Item> ItemList { get => Items.Values.ToList(); }
		public bool HasKey(System.UInt32 id) => Items.ContainsKey(id);
		public Item this[System.UInt32 id] => Items[id];
		public int Count {get; set; }

		public virtual void Load(string path)
		{
			TypeFunc();
			var table = ConvertCSVtoDataTable(path);
			var rows = table.Rows;
			Count = rows.Count;
			for (int i = 0; i < Count; ++i)
			{
				Item t = new Item(rows[i].ItemArray);
				Items.Add(t.id, t);
			}
		}

		void TypeFunc()
		{
			types["id"] = typeof(UInt32);
			types["maxstack"] = typeof(Int32);
			types["level"] = typeof(Byte);
			types["usage"] = typeof(Byte);
			types["name"] = typeof(String);
			types["resource"] = typeof(String);
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
