using UnityEngine;

public interface IAction
{
	void Cancel();
}
public class ActionScheduler : MonoBehaviour
{
	IAction currentAction;

	public void StartAction(IAction action)
	{
		if (currentAction == action)
			return;

		if (currentAction == null)
		{
			action.Cancel();
		}
		currentAction = action;
	}
}

public enum CharacterState
{
	Idle,
	Move,
	Chase,
	Attack,
}

public class EventState
{
	public CharacterState CurState { get; set; } = CharacterState.Idle;

	public bool ChangeState(CharacterState state)
	{
		if (CurState == state)
			return false;
		else
			CurState = state;

		return true;
	}
}
