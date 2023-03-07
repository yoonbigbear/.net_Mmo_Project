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
	public struct Portal
	{
		public readonly UInt32 id;
		public readonly UInt32 world;
		public readonly UInt32 destination;
		public readonly Single[] portal_pos;
		public Portal(object[] param)
		{
			this.id = (UInt32)param[0];
			this.world = (UInt32)param[1];
			this.destination = (UInt32)param[2];
			this.portal_pos = (Single[])param[3];
		}
	}


	public class PortalTable
	{
		protected Dictionary<System.UInt32, Portal> Portals = new ();
		protected Dictionary<string, Type> types = new ();

		public List<Portal> PortalList { get => Portals.Values.ToList(); }
		public bool HasKey(System.UInt32 id) => Portals.ContainsKey(id);
		public Portal this[System.UInt32 id] => Portals[id];
		public int Count {get; set; }

		public virtual void Load(string path)
		{
			TypeFunc();
			var table = ConvertCSVtoDataTable(path);
			var rows = table.Rows;
			Count = rows.Count;
			for (int i = 0; i < Count; ++i)
			{
				Portal t = new Portal(rows[i].ItemArray);
				Portals.Add(t.id, t);
			}
		}

		void TypeFunc()
		{
			types["id"] = typeof(UInt32);
			types["world"] = typeof(UInt32);
			types["destination"] = typeof(UInt32);
			types["portal_pos"] = typeof(Single[]);
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
