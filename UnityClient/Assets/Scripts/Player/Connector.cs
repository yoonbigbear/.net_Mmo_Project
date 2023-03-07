using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Sockets;

[Serializable]
public struct ServerInfo
{
	public string name;
	public string address;
	public short port;
}

[Serializable]
public struct ServerList
{
	public List<ServerInfo> list;
}


[Serializable]
public struct AccountInfo
{
	public AccountInfo(string name, int acctId)
	{
		this.name = new string(name);
		this.acctId = acctId;
	}

	public string name { get; set; }
	public int acctId { get; set; }
}

public class Connector
{
	static readonly HttpClient client = new HttpClient();
	//서버에 소켓 연결 시도
	public static async Task<Socket?> ConnectAsync(string ip, short port)
	{
		var endpoint = new IPEndPoint(IPAddress.Parse(ip), port);
		try
		{
			Socket socket = new Socket(
				addressFamily: AddressFamily.InterNetwork,
				socketType: SocketType.Stream,
				protocolType: ProtocolType.Tcp);

			await socket.ConnectAsync(remoteEP: endpoint)
				.ContinueWith(continuationAction: AfterConnect);
			return socket;
		}
		catch (Exception e)
		{
			Console.WriteLine($"Connect Failed {e}");
			return null;
		}
	}

	public static void AfterConnect(Task task)
	{
		if (task.IsCompletedSuccessfully)
		{
			Console.WriteLine("Socket Connected");
		}
		else
		{
			Console.WriteLine("Connection Failed");
		}
	}


	public static AccountInfo? CreateAccount(string nickname)
	{
		string uri = "http://localhost:8000/createaccount";

		AccountInfo req = new AccountInfo(nickname, 0);

		var content = new StringContent(
			JsonConvert.SerializeObject(req)
			, Encoding.UTF8
			, "application/json");

		using (var resp = client.PostAsync(uri, content))
		{
			resp.Wait(5000);

			if (resp.IsCompletedSuccessfully)
			{
				string responseBody = resp.Result.Content.ReadAsStringAsync().Result;
				{
					JObject json = JObject.Parse(responseBody);
					if (!json.HasValues)
						return null;

					if (!json.ContainsKey("name"))
						return null;
					if (!json.ContainsKey("acctId"))
						return null;

					string name = (string)json["name"];
					int acctId = (int)json["acctId"];

					return new AccountInfo(name, acctId);
				}
			}
		}
		return null;
	}


	public static ServerList? FetchServerList()
	{
		string uri = "http://localhost:8000/serverlist";

		var content = new StringContent("{}");

		using (var resp = client.PostAsync(uri, content))
		{
			resp.Wait(5000);

			if (resp.IsCompletedSuccessfully)
			{
				string responseBody = resp.Result.Content.ReadAsStringAsync().Result;
				{
					ServerList serverList = new();
					serverList.list = new();
					JObject json = JObject.Parse(responseBody);
					if (!json.HasValues)
						return null;

					if (!json.ContainsKey("list"))
						return null;

					JToken? list = json["list"];
					if (list != null && list.HasValues)
					{
						var arr = list.ToArray();
						foreach (var item in arr)
						{
							ServerInfo info = new();
							info.name = (string)item["name"];
							info.address = (string)item["address"];
							info.port = (short)item["port"];
							serverList.list.Add(info);
						}
					}

					return serverList;
				}
			}
		}
		return null;
	}

}
