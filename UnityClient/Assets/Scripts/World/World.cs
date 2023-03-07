using UnityEngine;

public class World : MonoBehaviour
{
	[SerializeField] bool Online = true;

	private void Awake()
	{
		if (Online)
		{
			var go = GameObject.FindGameObjectWithTag("Player");
			if (go == null)
			{
				Instantiate(Resources.Load<FieldObject>("Player"));
			}
		}
	}
}
