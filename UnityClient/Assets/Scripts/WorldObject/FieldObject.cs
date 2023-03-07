
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class FieldObject : MonoBehaviour
{
	public Mover mover = new();
	[SerializeField] public uint ObjId;
	public uint WorldId { get; set; }

	public partial void Initialize();

	private void Start()
	{
		Initialize();
	}

	protected void Update()
	{
		UpdateGui();

		UpdateMove();

		UpdateAnimation();
	}

	void UpdateMove()
	{
		bool ret = mover.MoveUpdate(Time.deltaTime);
		transform.localPosition = mover.Position;
	}

	public bool CanAttack()
	{
		if (IsDead) 
			return false;

		return true;
	}
}
