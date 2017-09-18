using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    private Variables var;
    private GameObject[] enemies;
    public bool gameWon = false;

    //Instructions
    private Canvas inst;
    private bool instOn = false;

    // Use this for initialization
    void Start()
    {
        var = GameObject.Find("Variables").GetComponent<Variables>();

        //Instructions 
        inst = GameObject.Find("Instructions Canvas").GetComponent<Canvas>();
        inst.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Instructions Pause
        if (Input.GetKeyDown(KeyCode.Escape) && !instOn)
        {
            Time.timeScale = 0;
            inst.enabled = true;
            instOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && instOn)
        {
            Time.timeScale = 1;
            inst.enabled = false;
            instOn = false;
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
        yield return new WaitForSeconds(4.0f);
        var.booty = 10000;
        SceneManager.LoadScene("menu"); //Restart game after 4 seconds.
    }
}
