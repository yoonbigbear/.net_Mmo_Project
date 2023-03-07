using Google.FlatBuffers;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;

public partial class Player
{
	[Serializable]
	public class Item
	{
		public byte ItemUsage;
		public byte ItemLevel;
		public uint TableId;
		public int Count;
		public ulong DbId;
		public string Name;

		public ItemInfoT ToItemInfoT()
		{
			ItemInfoT item = new();
			item.DbId = this.DbId;
			item.Count = this.Count;
			item.TId = this.TableId;
			return item;
		}
	}

	public Dictionary<uint, Dictionary<ulong, Item>> Inventory { get; set; } = new();

	public void AddItem_Req()
	{
		FlatBufferBuilder fbb = new(128);
		AddItemReqT req = new();

		req.Ids = new();
		req.Values = new();

		req.Ids.Add(1000001);
		req.Ids.Add(1000002);
		req.Ids.Add(1000003);
		req.Ids.Add(1000004);
		req.Ids.Add(20000001);
		req.Ids.Add(20000002);

		req.Values.Add(1);
		req.Values.Add(2);
		req.Values.Add(3);
		req.Values.Add(4);
		req.Values.Add(500);
		req.Values.Add(1000);

		fbb.Finish(AddItemReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.AddItemReq, fbb.Offset, fbb.SizedByteArray());
	}

	void AddItem_Resp(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		AddItemRespT resp = AddItemResp.GetRootAsAddItemResp(bb).UnPack();

		Debug.Assert(resp.ErrorCode == 0);

		resp.Items.ForEach(item =>
		{
			AddInventory(item);
		});

		UpdateInventoryWindow();
	}

	void AddInventory(ItemInfoT param)
	{
		var tId = param.TId;

		// 1. Find item table data
		var itemTable = TableData.Instance.itemTable;
		Debug.Assert(itemTable.HasKey(tId));
		var tableData = itemTable[tId];

		// 2. if is new item, create new container
		if (!Inventory.ContainsKey(tId))
			Inventory.Add(tId, new Dictionary<ulong, Item>());

		// 3. Add inventory
		var items = Inventory[tId];
		if (!items.ContainsKey(param.DbId))
		{
			var newItem = new Item
			{
				Count = param.Count,
				TableId = tId,
				ItemLevel = tableData.level,
				ItemUsage = tableData.usage,
				DbId = param.DbId,
				Name = tableData.name
			};
			items.Add(newItem.DbId, newItem);
		}
		else
		{
			items[param.DbId].Count = param.Count;
		}
	}

	public void UpdateInventoryWindow()
	{
		DataTable table = new DataTable();
		table.Columns.Add("dbid", typeof(ulong));
		table.Columns.Add("tid", typeof(uint));
		table.Columns.Add("count", typeof(int));

		foreach (var items in Inventory.Values)
		{
			foreach (var item in items.Values)
			{
				table.Rows.Add(item.DbId, item.TableId, item.Count);
			}
		}
		//Program.clientInfo.dataGridView1.InvokeIfRequired(e =>
		//{
		//	Program.clientInfo.dataGridView1.DataSource = table;
		//});
	}
}