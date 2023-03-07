using UnityEngine;



public class PlayerController : MonoBehaviour
{
	FieldObject _target = null;
	Player _player = null;
	EventState _state { get; set; }= new();

	const float _inputInterval = 0.5f;
	float _inputAcc = 0;

	[SerializeField] float _weaponRange = 2f;
	[SerializeField] float _attackInterval= 3f;

	private static Ray GetMouseRay() => Camera.main.ScreenPointToRay(Input.mousePosition);
	private bool IsInRange(Vector3 pos) => Vector3.Distance(transform.position, pos) < _weaponRange;

	private void Start()
	{
		_player = GetComponent<Player>();
	}

	private void Update()
	{
		_inputAcc += Time.deltaTime;

		if (!_target)
		{
			_state.ChangeState(CharacterState.Idle);
		}

		if (_player.inAnimation)
			return;

		//input
		if (Input.GetMouseButton(0))
		{
			RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
			foreach(var hit in hits)
			{
				_target = hit.transform.GetComponent<FieldObject>();
				if (_target == null)
				{
					_state.ChangeState(CharacterState.Move);
					//move to position

					_player.MoveSync(5, hit.point, true);

					if (_inputAcc > _inputInterval)
					{
						_player.Transform_Req();
						_inputAcc = 0.0f;
						return;
					}
				}
				else
				{
					if (!_target.CanAttack())
					{
						continue;
					}
				}
			}
		}

		if (Input.GetKey(KeyCode.Q))
		{
			_player.Attack(100001, _player.mover.Dir);
			_inputAcc = 0.0f;
			return;
		}

		AttackBehaviour();
	}

	void AttackBehaviour()
	{
		if (!_target || _target.IsDead)
			return;

		if (_state.CurState == CharacterState.Attack)
		{
			if (IsInRange(_target.mover.Position))
			{
				if (_inputAcc > _attackInterval)
				{
					_player.MoveSync(0, _player.mover.Position, true);
					var v = (_target.mover.Position - _player.mover.Position);
					_player.Attack(100001, v.normalized);

					_inputAcc = 0.0f;
				}
			}
			else
			{
				_state.ChangeState(CharacterState.Chase);
				_player.MoveSync(5, _target.mover.Position, true);
				_inputAcc = 0.0f;
			}
		}
		else if (_state.CurState == CharacterState.Chase)
		{
			if (IsInRange(_target.mover.Position))
			{
				_state.ChangeState(CharacterState.Attack);
				_player.MoveSync(0, _player.mover.Position, true);
				var v = (_target.mover.Position - _player.mover.Position);
				_player.Attack(100001, v.normalized);
				_inputAcc = 0.0f;
			}
			if (_inputAcc > _inputInterval)
			{
				_player.MoveSync(5, _target.mover.Position, true);
				_inputAcc = 0.0f;
			}
		}
		else
		{
			if (IsInRange(_target.mover.Position))
			{
				if (_state.ChangeState(CharacterState.Attack))
				{
					_player.MoveSync(0, _player.mover.Position, true);
					var v = (_target.mover.Position - _player.mover.Position);
					_player.Attack(100001, v.normalized);
					_inputAcc = 0.0f;
				}
			}
			else
			{
				if (_state.ChangeState(CharacterState.Chase))
				{
					_player.MoveSync(5, _target.mover.Position, true);
					_inputAcc = 0.0f;
				}
			}
		}
	}

}
