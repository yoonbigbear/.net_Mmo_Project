using TCPCore;
using System.Data;
using System.Data.SqlClient;


namespace TCPUtil
{
	public class MSSQL
	{
		//config 파일에 가지고 있도록
		public static string AccountDbStr { get; set; }
		public static string GameDbStr { get; set; }

		//public void Start(DBConfig config)
		//{
		//	AccountDbStr = config.Account;
		//	GameDbStr = config.Game;
		//}

		public void StoredProcedure(string db, string sp)
		{
			using (SqlConnection conn = new SqlConnection(db))
			using (SqlCommand cmd = new SqlCommand(sp, conn))
			{
				conn.Open();


				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "sp_stored1";
				SqlParameter pin1 = new SqlParameter("id", SqlDbType.VarChar);
				pin1.Value = "아이디";
				cmd.Parameters.Add(pin1);

				SqlParameter out1 = new SqlParameter("RESULT", SqlDbType.VarChar, 1);
				cmd.Parameters.Add(out1).Direction = ParameterDirection.Output;

				SqlParameter out2 = new SqlParameter("ERROR_MSG", SqlDbType.VarChar, 30);
				cmd.Parameters.Add(out2).Direction = ParameterDirection.Output;

				cmd.ExecuteNonQuery();

				string outstr1 = out1.Value.ToString();
				string outstr2 = out2.Value.ToString();

				using (SqlDataReader rd = cmd.ExecuteReader())
				{

				}
			}
		}

		public void StoredProcedure(string db, string sp, params object[] paramList)
		{
			using (SqlConnection conn = new SqlConnection(db))
			using (SqlCommand cmd = new SqlCommand(sp, conn))
			{
				conn.Open();


				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "sp_stored1";
				SqlParameter pin1 = new SqlParameter("id", SqlDbType.VarChar);
				pin1.Value = "아이디";
				cmd.Parameters.Add(pin1);

				SqlParameter out1 = new SqlParameter("RESULT", SqlDbType.VarChar, 1);
				cmd.Parameters.Add(out1).Direction = ParameterDirection.Output;

				SqlParameter out2 = new SqlParameter("ERROR_MSG", SqlDbType.VarChar, 30);
				cmd.Parameters.Add(out2).Direction = ParameterDirection.Output;

				cmd.ExecuteNonQuery();

				string outstr1 = out1.Value.ToString();
				string outstr2 = out2.Value.ToString();

				using (SqlDataReader rd = cmd.ExecuteReader())
				{

				}
			}
		}

		public void BulkCopy(DataTable table, string tableName)
		{
			using (SqlConnection conn = new SqlConnection(GameDbStr))
			{
				//using (var adapter = new SqlDataAdapter($"select top 0 * from inventory", conn))
				//{
				//	adapter.Fill(table);
				//}
				conn.Open();

				//for(var i = 0; i < table.Columns.Count; i++)
				//{
				//	var row = table.NewRow();
				//	row["Value"] = Guid.NewGuid().ToString();
				//	table.Rows.Add(row);
				//}

				using (var bulk = new SqlBulkCopy(conn))
				{
					bulk.DestinationTableName = tableName;
					bulk.WriteToServer(table);
				}
			}
		}

		public int ReadAccount(string name)
		{
			if (name.ToCharArray().Length > 10)
			{
				Logger.DebugError("account name must be less than 10 characters");
				return -1;
			}

			using (SqlConnection conn = new SqlConnection(AccountDbStr))
			using (SqlCommand cmd = new SqlCommand(
				$"select top (1) [acct_id] from account.dbo.account where name = N'{name}'"
				, conn))
			{
				try
				{
					conn.Open();

					using (SqlDataReader rd = cmd.ExecuteReader())
					{
						while (rd.Read())
						{
							int acctId = (int)rd["acct_id"];
							return acctId;
						}
					}
				}
				catch (Exception e)
				{
					Logger.DebugError(e.Message);
					Logger.LogError(e.Message);
				}
			}

			return -1;
		}

		public int CreateAccount(string name)
		{
			if (name.Length > 10)
			{
				Logger.DebugError("account name must be less than 10 characters");
				return -1;
			}

			using (SqlConnection conn = new SqlConnection(AccountDbStr))
			using (SqlCommand cmd = new SqlCommand(
				@$"insert dbo.account output inserted.* values(N'{name}')",
				conn))
			{
				try
				{
					conn.Open();

					using (SqlDataReader rd = cmd.ExecuteReader())
					{
						while (rd.Read())
						{
							int acctId = (int)rd["acct_id"];
							return acctId;
						}
					}
				}
				catch (Exception e)
				{
					Logger.DebugError(e.Message);
					Logger.LogError(e.Message);
				}
			}

			return -1;
		}

//		public List<WorldObjectInfo> ReadCharacters(int acctId)
//		{
//			List<WorldObjectInfo> list = new();

//			using (SqlConnection conn = new SqlConnection(AccountDbStr))
//			using (SqlCommand cmd = new SqlCommand(
//				@$"select [db_id], [name], [world_id], 
//[pos_x], [pos_y], [pos_z] from account.dbo.characters where acct_id = {acctId}"
//				, conn))
//			{
//				try
//				{
//					conn.Open();

//					using (SqlDataReader rd = cmd.ExecuteReader())
//					{
//						while (rd.Read())
//						{

//							long dbId = (long)rd["db_id"];
//							string name = (string)rd["name"];
//							int worldId = (int)rd["world_id"];
//							float x = Convert.ToSingle(rd["pos_x"]);
//							float y = Convert.ToSingle(rd["pos_y"]);
//							float z = Convert.ToSingle(rd["pos_z"]);

//							list.Add(new WorldObjectInfo(
//								dbId,
//								worldId,
//								name, 0, 0, 0));
//						}
//					}
//				}
//				catch (Exception e)
//				{
//					Logger.DebugError(e.Message);
//					Logger.LogError(e.Message);
//				}
//			}

//			return list;
//		}

//		public WorldObjectInfo? ReadCharacters(int acctId, string name)
//		{
//			using (SqlConnection conn = new SqlConnection(AccountDbStr))
//			using (SqlCommand cmd = new SqlCommand(
//				@$"select [db_id], [name], [world_id], [pos_x], [pos_y], [pos_z] 
//			from account.dbo.characters 
//			where acct_id = {acctId} and name = N'{name}'"
//				, conn))
//			{
//				try
//				{
//					conn.Open();

//					using (SqlDataReader rd = cmd.ExecuteReader())
//					{
//						while (rd.Read())
//						{

//							long dbId = (long)rd["db_id"];
//							int worldId = (int)rd["world_id"];
//							float x = Convert.ToSingle(rd["pos_x"]);
//							float y = Convert.ToSingle(rd["pos_y"]);
//							float z = Convert.ToSingle(rd["pos_z"]);

//							return new WorldObjectInfo(
//								dbId,
//								worldId,
//								name, x, y, z);
//						}
//					}
//				}
//				catch (Exception e)
//				{
//					Logger.DebugError(e.Message);
//					Logger.LogError(e.Message);
//				}
//			}

//			return null;
//		}

//		public WorldObjectInfo? CreateCharacter(long dbId, int acctId, string name)
//		{
//			using (SqlConnection conn = new SqlConnection(AccountDbStr))
//			using (SqlCommand cmd = new SqlCommand(@$"
//IF NOT EXISTS (SELECT [name] FROM [account].[dbo].[characters] WHERE [name] = N'{name}')
//BEGIN
//INSERT into characters values({dbId}, {acctId}, N'{name}', 1, 0,0,0, GETUTCDATE())
//END
//ELSE
//BEGIN 
//RAISERROR ('name is already in use.',16,1)
//END",
//				conn))
//			{
//				try
//				{
//					conn.Open();

//					using (SqlDataReader rd = cmd.ExecuteReader())
//					{
//						return new WorldObjectInfo(dbId, 1, name, 0, 0, 0);
//					}
//				}
//				catch (Exception e)
//				{
//					Logger.DebugError(e.Message);
//					Logger.LogError(e.Message);
//				}
//			}

//			return null;
//		}
	}
}