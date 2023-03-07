using UnityEngine;

public class Factory : MonoBehaviour
{
	static FieldObject CreateFieldObject()
	{
		var newObject = Instantiate(Resources.Load<FieldObject>("FieldObject"));
		return newObject;
	}
}
