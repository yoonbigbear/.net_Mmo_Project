using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HealthBar : MonoBehaviour
{
	[SerializeField] Image _healthBar;
	[SerializeField] Canvas _worldSpaceCanvas;

	public void SyncHealth(long hp, long maxHp)
	{
		_healthBar.fillAmount = (float)((double)hp / maxHp);
	}

	public void Update()
	{
		_worldSpaceCanvas.transform.LookAt(transform.position + Camera.main.transform.forward);
	}
}