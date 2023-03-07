using System;
using System.Threading;

namespace MMOLib
{
	public class IdGen
	{
		public enum IdType : ulong
		{
			None = 0,
			Player = 1,
			Item = 2,
			Object = 3,
			Log = 4,
			End = 9
		}

		static int _guidSeqOffset = 0;
		const ulong _typeOffset = 1000;
		const ulong _uniqueOffset = 1000;
		const ulong _timeOffset = 10000000000000;

		public static ulong GenerateGUID(IdType type, int serverid)
		{
			ulong guid = 0;
			var uniqueSeq = (ulong)Interlocked.Increment(ref _guidSeqOffset);
			if (uniqueSeq > 900)
				_guidSeqOffset = 0;

			//type
			guid += (ulong)type * _typeOffset * _typeOffset * _timeOffset;
			//uniqueSeq
			guid += (ulong)uniqueSeq * _uniqueOffset * _timeOffset;
			//serverId
			guid += (ulong)serverid * _timeOffset;
			//mstime
			guid += (ulong)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

			return guid;
		}

		static int _eidSeqOffset = 0;
		public static int GenerateEID()
		{
			return Interlocked.Increment(ref _eidSeqOffset);
		}
	}

}
