
using UnityEngine;

public class AnimatorComponent
{
	public Animator Animator { get; set; }

	public bool inAnimation = false;

	public readonly int HashAttack = Animator.StringToHash("Attack");
	public readonly int HashDie = Animator.StringToHash("Die");
	public readonly int HashForwardSpeed = Animator.StringToHash("ForwardSpeed");
}
