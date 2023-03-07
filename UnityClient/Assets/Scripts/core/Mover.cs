
using UnityEngine;
using UnityEngine.UIElements;

public static class Converter
{
	public static UnityEngine.Vector3 ToUnityVector(this Vec3T V) =>
		new UnityEngine.Vector3(V.X, V.Z, V.Y);
	public static UnityEngine.Vector3 ToUnityVector(this System.Single[] V) =>
	new UnityEngine.Vector3(V[0], V[2], V[1]);
	public static float ToAngle(this UnityEngine.Vector3 v) => Mathf.Atan2(v.z, v.x);
	public static float ToAngle(this Vec3T v) => Mathf.Atan2(v.Y, v.X);
	public static Vec3T ToVec3T(this UnityEngine.Vector3 V)
	{
		var v = new Vec3T();
		v.X = V.x;
		v.Y = V.z;
		v.Z = V.y;
		return v;
	}
}

public sealed class Mover
{
	public Vector3 Position = new();
	public Vector3 EndPos = new();
	public Vector3 Dir = new();

	public int Speed { get; private set; }

	public void MoveSync(int speed, Vector3 EndPos)
	{
		this.EndPos = EndPos;
		this.Speed = speed;
		this.Dir = Vector3.Normalize(EndPos - Position);
	}

	public bool MoveUpdate(float dt)
	{
		if (Speed == 0)
			return false;

		var future = Next(dt);
		var futureLen = future.sqrMagnitude;
		var curLen = (EndPos - Position).sqrMagnitude;

		if (futureLen > curLen)
		{
			Position = EndPos;
			Speed = 0;
			return true;
		}

		//move position
		Position += future;

		return false;
	}

	public void TransformSync(int speed, Vector3 curPos, Vector3 endPos, Vector3 dir)
	{
		this.EndPos = endPos;
		this.Position = curPos;
		this.Speed = speed;
		this.Dir = dir;
	}

	// Calculate future move length position
	Vector3 Next(float dt) => (Dir * this.Speed) * dt;

	// Predict future end position for client move input
	void Next(float dt, float future, out Vector3 next) => next = Next(dt) * future;

}