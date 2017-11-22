﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public GameObject loc;

	void Update () {
		Vector3 target = loc.transform.position;
		target.y = transform.position.y;
		transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime);	
	}
}
