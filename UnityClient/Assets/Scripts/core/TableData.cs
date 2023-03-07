using Data;
using static Data.DropGroupTableEx;
using System.Collections.Generic;
using System;

public class Singleton<T> where T : class, new()
{
	protected Singleton() { }
	protected static readonly Lazy<T> instance = new Lazy<T>(() => new T(), false);
	public static T Instance { get { return instance.Value; } }
}
public partial class TableData : Singleton<TableData>
{
	const string csvPath = "Assets\\scripts\\genCsv\\";

	public Data.ItemTable itemTable { get; set; }
	public Data.DropGroupTableEx dropGroupTableEx { get; set; }
	public Data.ClassBaseTable ClassBaseTable { get; set; }
	public Data.WorldTable WorldTable { get; set; }
	public Data.SkillTable SkillTable { get; set; }
	public Data.PortalTable PortalTable { get; set; }
	public Data.ObjectBaseTable ObjectBaseTable { get; set; }
	

	public void Start()
	{
		itemTable = new Data.ItemTable();
		itemTable.Load($"{csvPath}item.csv");

		dropGroupTableEx = new Data.DropGroupTableEx();
		dropGroupTableEx.Load($"{csvPath}DropGroup.csv");

		ClassBaseTable = new Data.ClassBaseTable();
		ClassBaseTable.Load($"{csvPath}ClassBase.csv");

		WorldTable = new Data.WorldTable();
		WorldTable.Load($"{csvPath}World.csv");

		SkillTable = new Data.SkillTable();
		SkillTable.Load($"{csvPath}Skill.csv");

		PortalTable = new Data.PortalTable();
		PortalTable.Load($"{csvPath}Portal.csv");

		ObjectBaseTable = new Data.ObjectBaseTable();
		ObjectBaseTable.Load($"{csvPath}ObjectBase.csv");
	}

	static public object ConvertTypes(string type, string value)
	{
		var splitValue = value.Split(':');
		switch (type.ToLower())
		{
			case "byte[]":
				{
					byte[] arr = new byte[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToByte(splitValue[i]);
					return arr;
				}
			case "int16[]":
				{
					Int16[] arr = new Int16[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToInt16(splitValue[i]);
					return arr;
				}
			case "uint16[]":
				{
					UInt16[] arr = new UInt16[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToUInt16(splitValue[i]);
					return arr;
				}
			case "int32[]":
				{
					Int32[] arr = new Int32[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToInt32(splitValue[i]);
					return arr;
				}
			case "uint32[]":
				{
					UInt32[] arr = new UInt32[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToUInt32(splitValue[i]);
					return arr;
				}
			case "int64[]":
				{
					Int64[] arr = new Int64[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToInt64(splitValue[i]);
					return arr;
				}
			case "uint64[]":
				{
					UInt64[] arr = new UInt64[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToUInt64(splitValue[i]);
					return arr;
				}
			case "single[]":
				{
					Single[] arr = new Single[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToSingle(splitValue[i]);
					return arr;
				}
			case "double[]":
				{
					Double[] arr = new Double[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToDouble(splitValue[i]);
					return arr;
				}
			case "string[]":
				return splitValue;
			case "bool[]":
				{
					Boolean[] arr = new Boolean[splitValue.Length];
					for (int i = 0; i < arr.Length; i++)
						arr[i] = Convert.ToBoolean(splitValue[i]);
					return arr;
				}
			case "byte":
				return Convert.ToByte(value);
			case "ubyte":
				return Convert.ToSByte(value);
			case "short":
				return Convert.ToInt16(value);
			case "int16":
				return Convert.ToInt16(value);
			case "ushort":
				return Convert.ToUInt16(value);
			case "uint16":
				return Convert.ToUInt16(value);
			case "int":
				return Convert.ToInt32(value);
			case "int32":
				return Convert.ToInt32(value);
			case "uint":
				return Convert.ToUInt32(value);
			case "uint32":
				return Convert.ToUInt32(value);
			case "long":
				return Convert.ToInt64(value);
			case "int64":
				return Convert.ToInt64(value);
			case "ulong":
				return Convert.ToUInt64(value);
			case "uint64":
				return Convert.ToUInt64(value);
			case "float":
				return Convert.ToSingle(value);
			case "single":
				return Convert.ToSingle(value);
			case "double":
				return Convert.ToDouble(value);
			case "string":
				return value;
			case "bool":
				return Convert.ToBoolean(value);
			default:
				{
					return typeof(System.Enum);
				}
		}
	}
}
namespace Data
{
	public class DropGroupTableEx : Data.DropGroupTable
	{
		public Dictionary<uint, List<DropGroupEx>> OverrideTable = new();
		public Dictionary<uint, int> TotalPossibility = new();

		System.Random random = new();

		public struct DropGroupEx
		{
			public DropGroup data;
			public int possibility;
		}
		public override void Load(string path)
		{
			base.Load(path);

			int value = 0;
			foreach (var e in DropGroups)
			{
				if (!OverrideTable.ContainsKey(e.Value.groupid))
				{
					OverrideTable[e.Value.groupid] = new List<DropGroupEx>();
					value = 0;
				}
				value += e.Value.possibility;

				var dropGroupEx = new DropGroupEx();
				dropGroupEx.data = this[e.Key];
				dropGroupEx.possibility = value;
				OverrideTable[e.Value.groupid].Add(dropGroupEx);
				TotalPossibility[e.Value.groupid] = value;
			}
		}

		public uint Reward(uint groupId)
		{
			var total = TotalPossibility[groupId];

			var rand = random.Next(0, total);

			foreach (var e in OverrideTable[groupId])
			{
				if (e.possibility > rand)
					return e.data.drop_tid;
			}
			return 0;
		}
	}
}