using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transportScript : MonoBehaviour {

	public GameObject playerGO;

	public void transportPlayer()
	{
		playerGO.transform.position = transform.position;
	}
}
