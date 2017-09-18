using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPosition = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);

        transform.LookAt(targetPosition);
		
	}
}
