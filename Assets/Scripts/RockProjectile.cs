using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour {

    private Rigidbody rb;
    public AudioSource sound;
    private Collider collide;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        collide = GetComponent<Collider>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        rb.AddForce(Physics.gravity * rb.mass);

        if (transform.position.y <= -50)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Player Rock")
        {
            collide.isTrigger = false;
            Destroy(gameObject, sound.clip.length);
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "Enemy Rock")
        {
            collide.isTrigger = false;
            Destroy(gameObject, sound.clip.length);
        }
    }
}
