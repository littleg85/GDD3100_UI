using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

    private float solidDist = 10; //Max distance to be 100% solid
    private float dist;
    public GameObject player;
    private Renderer rend;
    private Collider colliderObj;
    private Collider colliderPlayer;

    private Vector3 closestSurfacePoint1;
    private Vector3 closestSurfacePoint2;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        colliderPlayer = player.GetComponent<Collider>();
        colliderObj = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

        closestSurfacePoint1 = colliderObj.ClosestPointOnBounds(colliderPlayer.transform.position);
        closestSurfacePoint2 = colliderPlayer.ClosestPointOnBounds(colliderObj.transform.position);
        dist = Vector3.Distance(closestSurfacePoint1, closestSurfacePoint2);

        if (dist < solidDist)
        {
            dist = solidDist;
        }

        if (dist >= 100.0f)
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.0f);
        }

        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, solidDist/dist);

        //Debug.Log(dist);
        //Debug.DrawLine(transform.position, colliderPlayer.transform.position, Color.yellow);
        //Debug.DrawLine(closestSurfacePoint1, closestSurfacePoint2, Color.magenta);
    }
}
