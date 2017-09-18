using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUI : MonoBehaviour {

    private Variables var;
    private Player player;
    private GameLogic GL;


    // Use this for initialization
    void Start () {

        var = GameObject.Find("Variables").GetComponent<Variables>();
        player = GameObject.Find("Player").GetComponent<Player>();
        GL = GameObject.Find("GameUI").GetComponent<GameLogic>();

    }

    // Update is called once per frame
    void Update()
    {
        //Display Health and Booty
        if (gameObject.transform.name == "pHealth")
        {
            gameObject.GetComponent<Text>().text = "Health: " + player.health;
        }

        if (gameObject.transform.name == "bootyText")
        {
            gameObject.GetComponent<Text>().text = "$" + var.booty;
        }

        //Game Over Screens
        if (GL.gameWon)
        {
            if (gameObject.transform.name == "Win Text")
            {
                gameObject.GetComponent<Text>().text = "You defeated all the pirates! Your booty is safe!";
            }
            
        }
        else if (player.health <= 0)
        {
            if (gameObject.transform.name == "Sunk Text")
            {
                gameObject.GetComponent<Text>().text = "You've been sunk! Your booty is gone!";
            }
        }
        else if (player.capsize)
        {
            if (gameObject.transform.name == "Capsize Text")
            {
                gameObject.GetComponent<Text>().text = "You've capsized! Your booty is gone!";
            }
        }
    }
}
