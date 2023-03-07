using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] uint _portal;

	private void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (player)
            {
				player.MovePortal_Req(_portal);
			}
        }
	}
}
