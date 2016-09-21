﻿using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public ObjectPoller theObjectPool;
	public float distanceBetween;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private float platformWidth;


	// Use this for initialization
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

			//Instantiate (thePlatform, transform.position, transform.rotation);
			GameObject newPlatform = theObjectPool.GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
		}
	}
}