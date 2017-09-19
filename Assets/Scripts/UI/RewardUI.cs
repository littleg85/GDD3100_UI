using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RewardUI : MonoBehaviour {

    private Variables var;
    public int bootyLost = 0;
    public int stars = 0;
    public Image starLeft;
    public Image starMid;
    public Image starRight;

    // Use this for initialization

    private void Awake()
    {
        starLeft.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 0);
        starMid.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 0);
        starRight.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 0);
    }
    void Start () {

        var = GameObject.Find("Variables").GetComponent<Variables>();

        //Unhide cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
	
	// Update is called once per frame
	void Update () {

        bootyLost = 10000 - var.booty;

        if (bootyLost == 0)
        {
            StartCoroutine(StarTimer());
            stars = 3;
            starLeft.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 1);
            starMid.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 1);
            starRight.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 1);
        }
        else if (bootyLost <= 2000 && bootyLost > 0)
        {
            stars = 2;
            starLeft.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 1);
            starMid.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 1);
        }
        else if (bootyLost < 10000 && bootyLost > 2000)
        {
            stars = 1;
            starLeft.color = new Color(starLeft.color.r, starLeft.color.g, starLeft.color.b, 1);
        }
        else if (bootyLost == 10000)
        {
            stars = 0;
        }
	}

    IEnumerator StarTimer()
    {
        yield return new WaitForSeconds(5);
    }
}
