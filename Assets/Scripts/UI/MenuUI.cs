using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MenuUI : MonoBehaviour {

    private Variables var;
    private bool clickedOn;

    //Clicked
    public bool healthClicked = false;
    public bool attackClicked = false;
    public bool aSpeedClicked = false;
    public bool pSpeedClicked = false;
    public bool mobClicked = false;
    public bool diffClicked = false;
    private Button play;

    private void Awake()
    {
        var = GameObject.Find("Variables").GetComponent<Variables>();
    }

    private void Start()
    {
        //Remove Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Store play button
        play = GameObject.Find("Play").GetComponent<Button>();

    }

    private void Update()
    {
        //Activate Play button
        if (healthClicked && attackClicked && aSpeedClicked && pSpeedClicked && mobClicked && diffClicked)
        {
            play.interactable = true;
        }
    }

    public void OnStartGame()
    {
        if (healthClicked && attackClicked && aSpeedClicked && pSpeedClicked && mobClicked && diffClicked)
        {
            SceneManager.LoadScene("Game1");
            Debug.Log("Scene Loaded");
        }
    }

    public void PlayerHealth()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "pHealth1")
        {
            var.healthLevel = 0;
            Debug.Log("Health Level 1");
                    }

        if (EventSystem.current.currentSelectedGameObject.name == "pHealth2")
        {
            var.healthLevel = 1;
            Debug.Log("Health Level 2");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "pHealth3")
        {
            var.healthLevel = 2;
            Debug.Log("Health Level 3");
        }
        healthClicked = true;
    }

    public void PlayerAttack()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "pAttack1")
        {
            var.attackLevel = 0;
            Debug.Log("Attack Level 1");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "pAttack2")
        {
            var.attackLevel = 1;
            Debug.Log("Attack Level 2");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "pAttack3")
        {
            var.attackLevel = 2;
            Debug.Log("Attack Level 3");
        }
        attackClicked = true;
    }

    public void PlayerAttackSpeed()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "aSpeed1")
        {
            var.fireRate = 2f;
            Debug.Log("Attack Speed Level 1");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "aSpeed2")
        {
            var.fireRate = 1f;
            Debug.Log("Attack Speed Level 2");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "aSpeed3")
        {
            var.fireRate = 0.5f;
            Debug.Log("Attack Speed Level 3");
        }
        aSpeedClicked = true;
    }

    public void PlayerSpeed()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "pSpeed1")
        {
            var.speed = 40000;
            Debug.Log("Speed Level 1");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "pSpeed2")
        {
            var.speed = 60000;
            Debug.Log("Speed Level 2");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "pSpeed3")
        {
            var.speed = 80000;
            Debug.Log("Speed Level 3");
        }
        pSpeedClicked = true;
    }

    public void PlayerMobility()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Mob1")
        {
            var.turnSpeed = 50;
            Debug.Log("Mobility Level 1");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Mob2")
        {
            var.turnSpeed = 75;
            Debug.Log("Mobility Level 2");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Mob3")
        {
            var.turnSpeed = 100;
            Debug.Log("Mobility Level 3");
        }
        mobClicked = true;
    }

    public void Difficulty()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "diff1")
        {
            var.difficulty = 0;
            Debug.Log("Difficulty Level 1");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "diff2")
        {
            var.difficulty = 1;
            Debug.Log("Difficulty Level 2");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "diff3")
        {
            var.difficulty = 2;
            Debug.Log("Difficulty Level 3");
        }

        if (EventSystem.current.currentSelectedGameObject.name == "diff4")
        {
            var.difficulty = 3;
            Debug.Log("Difficulty Level 4");
        }
        diffClicked = true;
    }

}
