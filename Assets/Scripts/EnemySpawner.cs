using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public Vector3 centerFront;
    public Vector3 sizeFront;
    public Vector3 centerBack;
    public Vector3 sizeBack;
    public Vector3 centerLeft;
    public Vector3 sizeLeft;
    public Vector3 centerRight;
    public Vector3 sizeRight;

    private Variables var;

    // Use this for initialization
    void Start () {
        var = GameObject.Find("Variables").GetComponent<Variables>();

        if (var.difficulty == 0)
        {
            SpawnEnemy0();
        }
        if (var.difficulty == 1)
        {
            SpawnEnemy0();
            SpawnEnemy1();
        }
        if (var.difficulty == 2)
        {
            SpawnEnemy0();
            SpawnEnemy1();
            SpawnEnemy2();
        }
        if (var.difficulty == 3)
        {
            SpawnEnemy0();
            SpawnEnemy1();
            SpawnEnemy2();
            SpawnEnemy3();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnEnemy0()
    {
        Vector3 pos = centerFront + new Vector3(Random.Range(-sizeFront.x / 2, sizeFront.x / 2), Random.Range(-sizeFront.y / 2, sizeFront.y / 2), Random.Range(-sizeFront.z / 2, sizeFront.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerFront + new Vector3(Random.Range(-sizeFront.x / 2, sizeFront.x / 2), Random.Range(-sizeFront.y / 2, sizeFront.y / 2), Random.Range(-sizeFront.z / 2, sizeFront.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerFront + new Vector3(Random.Range(-sizeFront.x / 2, sizeFront.x / 2), Random.Range(-sizeFront.y / 2, sizeFront.y / 2), Random.Range(-sizeFront.z / 2, sizeFront.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);
    }

    public void SpawnEnemy1()
    {
        Vector3 pos = centerLeft + new Vector3(Random.Range(-sizeLeft.x / 2, sizeLeft.x / 2), Random.Range(-sizeLeft.y / 2, sizeLeft.y / 2), Random.Range(-sizeLeft.z / 2, sizeLeft.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerLeft+ new Vector3(Random.Range(-sizeLeft.x / 2, sizeLeft.x / 2), Random.Range(-sizeLeft.y / 2, sizeLeft.y / 2), Random.Range(-sizeLeft.z / 2, sizeLeft.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerLeft + new Vector3(Random.Range(-sizeLeft.x / 2, sizeLeft.x / 2), Random.Range(-sizeLeft.y / 2, sizeLeft.y / 2), Random.Range(-sizeLeft.z / 2, sizeLeft.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);
    }

    public void SpawnEnemy2()
    {
        Vector3 pos = centerRight + new Vector3(Random.Range(-sizeRight.x / 2, sizeRight.x / 2), Random.Range(-sizeRight.y / 2, sizeRight.y / 2), Random.Range(-sizeRight.z / 2, sizeRight.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerRight + new Vector3(Random.Range(-sizeRight.x / 2, sizeRight.x / 2), Random.Range(-sizeRight.y / 2, sizeRight.y / 2), Random.Range(-sizeRight.z / 2, sizeRight.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerRight + new Vector3(Random.Range(-sizeRight.x / 2, sizeRight.x / 2), Random.Range(-sizeRight.y / 2, sizeRight.y / 2), Random.Range(-sizeRight.z / 2, sizeRight.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);
    }

    public void SpawnEnemy3()
    {
        Vector3 pos = centerBack + new Vector3(Random.Range(-sizeBack.x / 2, sizeBack.x / 2), Random.Range(-sizeBack.y / 2, sizeBack.y / 2), Random.Range(-sizeBack.z / 2, sizeBack.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerBack + new Vector3(Random.Range(-sizeBack.x / 2, sizeBack.x / 2), Random.Range(-sizeBack.y / 2, sizeBack.y / 2), Random.Range(-sizeBack.z / 2, sizeBack.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);

        pos = centerBack + new Vector3(Random.Range(-sizeBack.x / 2, sizeBack.x / 2), Random.Range(-sizeBack.y / 2, sizeBack.y / 2), Random.Range(-sizeBack.z / 2, sizeBack.z / 2));
        Instantiate(enemy, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        //Front Spawn
        Gizmos.color = new Color(1, 0, 0, 5f);
        Gizmos.DrawCube(centerFront, sizeFront);

        //Back Spawn
        Gizmos.DrawCube(centerBack, sizeBack);

        //left Spawn
        Gizmos.DrawCube(centerLeft, sizeLeft);

        //Right Spawn
        Gizmos.DrawCube(centerRight, sizeRight);
    }
}
