using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {

    //Make script accessible
    public static Variables var;

    //Gold earned
    public int booty = 0;

    //Upgrades
    //---------------------------
    //Attack
    public int attackLevel = 0;
    //Health
    public int healthLevel = 0;
    //Utility
    public int speed = 0;
    public int turnSpeed = 0;
    public float fireRate = 0.0f;

    //Enemy
    public int enemySpeed = 0;

    //Stage
    public int difficulty = 0;

    // Use this for initialization

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
