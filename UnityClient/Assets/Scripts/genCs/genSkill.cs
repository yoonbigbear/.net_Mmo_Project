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

	public enum skilltype : Int32
	{
		None = 0,
		active = 0,
		end = 1,
	}


	[StructLayout(LayoutKind.Sequential)]
#if NET5_0_OR_GREATER
	[SkipLocalsInit]
#endif
	public struct Skill
	{
		public readonly Int32 id;
		public readonly Int32 skilltype;
		public readonly Single max_range;
		public readonly Int32 halfangle;
		public readonly Int64 damage;
		public readonly Int32 cooldown;
		public readonly Int32 ani_time;
		public readonly Int32 hit_time;
		public readonly String name;
		public Skill(object[] param)
		{
			this.id = (Int32)param[0];
			this.skilltype = (Int32)param[1];
			this.max_range = (Single)param[2];
			this.halfangle = (Int32)param[3];
			this.damage = (Int64)param[4];
			this.cooldown = (Int32)param[5];
			this.ani_time = (Int32)param[6];
			this.hit_time = (Int32)param[7];
			this.name = (String)param[8];
		}
	}


	public class SkillTable
	{
		protected Dictionary<System.Int32, Skill> Skills = new ();
		protected Dictionary<string, Type> types = new ();

		public List<Skill> SkillList { get => Skills.Values.ToList(); }
		public bool HasKey(System.Int32 id) => Skills.ContainsKey(id);
		public Skill this[System.Int32 id] => Skills[id];
		public int Count {get; set; }

		public virtual void Load(string path)
		{
			TypeFunc();
			var table = ConvertCSVtoDataTable(path);
			var rows = table.Rows;
			Count = rows.Count;
			for (int i = 0; i < Count; ++i)
			{
				Skill t = new Skill(rows[i].ItemArray);
				Skills.Add(t.id, t);
			}
		}

		void TypeFunc()
		{
			types["id"] = typeof(Int32);
			types["skilltype"] = typeof(Int32);
			types["max_range"] = typeof(Single);
			types["halfangle"] = typeof(Int32);
			types["damage"] = typeof(Int64);
			types["cooldown"] = typeof(Int32);
			types["ani_time"] = typeof(Int32);
			types["hit_time"] = typeof(Int32);
			types["name"] = typeof(String);
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
