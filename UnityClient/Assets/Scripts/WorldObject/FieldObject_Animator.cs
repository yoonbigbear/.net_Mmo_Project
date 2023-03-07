using UnityEngine;

public partial class FieldObject
{
	public Animator Animator { get; set; }

	public bool inAnimation = false;

	public readonly int HashAttack = Animator.StringToHash("Attack");
	public readonly int HashDie = Animator.StringToHash("Die");
	public readonly int HashForwardSpeed = Animator.StringToHash("ForwardSpeed");

	[SerializeField] Transform handTransform;
	[SerializeField] AnimatorOverrideController weaponOverrider;

	public partial void Initialize() => Animator = GetComponent<Animator>();
	protected void MoveAni() => Animator?.SetFloat(HashForwardSpeed, mover.Speed);
	public void DeathAni() => Animator?.SetTrigger(HashDie);

	protected void UpdateAnimation()
	{
		if (IsDead) 
			return;

		if (inAnimation)
			return;

		if (Animator)
		{
			transform.LookAt(mover.EndPos, Vector3.up);
			MoveAni();
		}
	}
	public void Hit()
	{

	}
	public void End() => inAnimation = false;
	public void HitAni() => Debug.Log($"Attacked");
	public void AttackAni() => Animator?.SetTrigger(HashAttack);

	public void SpawnWeapon()
	{
		Instantiate(Resources.Load("Sword"), handTransform);
		Animator animator = GetComponent<Animator>();
		animator.runtimeAnimatorController = weaponOverrider;
	}
}
