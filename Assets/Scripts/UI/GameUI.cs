using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUI : MonoBehaviour {

    private Variables var;
    private Player player;
    private GameObject[] enemies;
    public GameObject enemy;
    public bool gameWon = false;

	// Use this for initialization
	void Start () {

        var = GameObject.Find("Variables").GetComponent<Variables>();
        player = GameObject.Find("Player").GetComponent<Player>();

        Instantiate(enemy, new Vector3(-150, 4, -50), transform.rotation);
        Instantiate(enemy, new Vector3(-150, 4, -150), transform.rotation);
        Instantiate(enemy, new Vector3(-50, 4, -150), transform.rotation);


        if (var.difficulty >= 1)
        {
            Instantiate(enemy, new Vector3(50, 4, -150), transform.rotation);
        }

        if (var.difficulty >= 2)
        {
            Instantiate(enemy, new Vector3(-150, 4, 50), transform.rotation);
            Instantiate(enemy, new Vector3(150, 4, -150), transform.rotation);
        }

        if (var.difficulty >= 3)
        {
            Instantiate(enemy, new Vector3(-150, 4, 150), transform.rotation);
            Instantiate(enemy, new Vector3(250, 4, -150), transform.rotation);
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.name == "pHealth")
        {
                gameObject.GetComponent<Text>().text = "Health: " + player.health;
        }

        if (gameObject.transform.name == "bootyText")
        {
            gameObject.GetComponent<Text>().text = "$"+ var.booty;
        }

        //Enemy count
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            StartCoroutine(GameWin());
            gameWon = true;
        }
    }

    IEnumerator GameWin()
    {
        yield return new WaitForSeconds(3.0f);
        var.booty = 10000;
        SceneManager.LoadScene("menu"); //Restart game after 5 seconds.
    }
}
