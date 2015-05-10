﻿using UnityEngine;
using System.Collections;

public class progen : MonoBehaviour {

	public Transform spawner;
	public GameObject platformStraight;
	public GameObject platformRotating;
	public GameObject PlatformCorner;

	public GameObject platformWallRun;

	void OnTriggerEnter(Collider other)
	{
		int choice = Random.Range (0, 4);
		// choice = 3; < Who did this??? :\
		if (other.tag == "Fake") {
		switch(choice)
			{
			case 0:
				Instantiate (platformStraight,spawner.position,spawner.rotation);
				Debug.Log ("spawn straight");
				break;
			case 1:
				Instantiate (platformRotating,spawner.position,spawner.rotation);
				Debug.Log ("spawn spin");
				break;
			case 2:
				Instantiate (PlatformCorner,spawner.position,spawner.rotation);
				break;

			case 3:
				Instantiate (platformWallRun,spawner.position,spawner.rotation);
				break;

			default:
				Instantiate (platformStraight,spawner.position,spawner.rotation);
				break;
			//Currently can only spawn straight or spinning platforms no corners
			
			}


		}
	}
}