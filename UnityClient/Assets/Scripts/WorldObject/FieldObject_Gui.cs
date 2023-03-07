using UnityEngine;

public partial class FieldObject
{
	[SerializeField] HealthBar _GUIHealthBar;

	void UpdateGui()
	{
		if (_GUIHealthBar != null && _GUIHealthBar.isActiveAndEnabled)
		{
			_GUIHealthBar.SyncHealth(Stats64[(int)SyncVar64.Hp], Stats64[(int)SyncVar64.MaxHp]);
		}
	}

}
