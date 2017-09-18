using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.up * Input.GetAxis("Mouse ScrollWheel") * 20000f * Time.deltaTime);

	}
}
