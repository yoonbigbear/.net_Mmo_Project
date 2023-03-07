
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//debug
public partial class Player
{
	Vector3 _debugForward = new Vector3();
	Vector3 _debugPosition = new Vector3();
	float _debugAngle = 0;
	float _debugDist = 0;

	void DebugSector(int skillTid, Vector3 dir, Vector3 start)
	{
		var table = TableData.Instance.SkillTable[skillTid];

		_debugPosition = start;
		_debugForward = dir;
		_debugAngle = table.halfangle;
		_debugDist = table.max_range;
	}

	private void OnDrawGizmos()
	{
		Handles.color = Color.red;
		Handles.DrawSolidArc(_debugPosition, Vector3.up, _debugForward, _debugAngle, _debugDist);
	}
}