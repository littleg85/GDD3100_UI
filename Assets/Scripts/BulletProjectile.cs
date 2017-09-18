using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    private Rigidbody rb;
    public AudioSource sound;
    private Collider collide;
    private Renderer[] rend;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        collide = GetComponent<Collider>();
        rend = GetComponentsInChildren<Renderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y <= -50)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Player Bullet")
        {
            collide.isTrigger = false;
            rb.detectCollisions = false;
            foreach (Renderer r in rend)
            {
                r.enabled = false;
            }
            Destroy(gameObject, sound.clip.length);
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "Enemy Bullet")
        {
            collide.isTrigger = false;
            rb.detectCollisions = false;
            foreach (Renderer r in rend)
            {
                r.enabled = false;
            }
            Destroy(gameObject, sound.clip.length);
        }

        if (other.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}