using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Target;

	private void Start()
	{
		var go = GameObject.FindGameObjectWithTag("Player");
		if (go != null)
			Target = go.transform;
	}
	// Update is called once per frame
	void LateUpdate()
    {
		if (Target != null)
			transform.position = Target.position;
    }
}
