using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private Variables var;
    public GameObject booty;

    //Weapons
    public GameObject rockPrefab;
    public GameObject bulletPrefab;
    public GameObject cannonballPrefab;
    public GameObject projectileSpawn;
    public GameObject cannonRight1;
    public GameObject cannonRight2;
    public GameObject cannonLeft1;
    public GameObject cannonLeft2;
    public GameObject cannonFront;
    private float fireRate;
    private float nextFire = 0.0f;
    private float dist;

    //Health
    private int health = 100;

    //Audio
    public AudioSource damage;
    public AudioSource sink;
    private bool sinkPlayed = false;

    //Boat randomizer
    public GameObject boatLevel0;
    public GameObject boatLevel1;
    public GameObject boatLevel2;
    public GameObject boatLevel3;
    public GameObject cannons;
    private int randHealth;
    private int randAttack;
    private BoxCollider boxCollider;


    // Use this for initialization
    void Start()
    {
        damage = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        var = GameObject.Find("Variables").GetComponent<Variables>();

        //Hide children
        boatLevel0.SetActive(false);
        boatLevel1.SetActive(false);
        boatLevel2.SetActive(false);
        boatLevel3.SetActive(false);
        cannons.SetActive(false);

        randHealth = Random.Range(0, 4);
        randAttack = Random.Range(0, 3);

        while (randHealth == 0 && randAttack == 2)
        {
            randHealth = Random.Range(0, 4);
            randAttack = Random.Range(0, 3);
        }


        //Health randomizer
        if (randHealth == 0)
        {
            boatLevel0.SetActive(true);
            health = 10;
            boxCollider.center = new Vector3(0, 2, 0);
            boxCollider.size = new Vector3(2, 3, 4);
        }

        if (randHealth == 1)
        {
            boatLevel1.SetActive(true);
            health = 30;
        }

        if (randHealth == 2)
        {
            boatLevel2.SetActive(true);
            health = 50;
        }

        if (randHealth == 3)
        {
            boatLevel3.SetActive(true);
            health = 100;
        }

        //Attack randomizer
        if (randAttack == 0)
        {

        }

        if (randAttack == 1)
        {

        }

        if (randAttack == 2)
        {
            cannons.SetActive(true);
        }

        fireRate = Random.Range(2f, 3f);

    }


    // Update is called once per frame
    void Update () {

        dist = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);

        if (health > 0f)
        {
            //Move toward island
            transform.LookAt(booty.transform);
            rb.AddForce(transform.forward * var.enemySpeed * Time.deltaTime, ForceMode.Impulse);

            //Attack
            if (randAttack == 0 && Time.time > nextFire && dist <= 25f)
            {
                //Rock
                GameObject rock = Instantiate(rockPrefab, projectileSpawn.transform.position, transform.rotation);
                rock.tag = "Enemy Rock";
                Rigidbody rockrb = rock.GetComponent<Rigidbody>();
                rockrb.AddForce(transform.up * 300f, ForceMode.Impulse);
                rockrb.AddForce(projectileSpawn.transform.forward * 150f, ForceMode.Impulse);

                nextFire = Time.time + fireRate;
            }

            if (randAttack == 1 && Time.time > nextFire && dist <= 25f)
            {
                //Bullets
                GameObject bullet1 = Instantiate(bulletPrefab, projectileSpawn.transform.position, transform.rotation);
                bullet1.tag = "Enemy Bullet";
                Rigidbody bullet1rb = bullet1.GetComponent<Rigidbody>();
                bullet1rb.AddForce(projectileSpawn.transform.forward * 300f, ForceMode.Impulse);

                GameObject bullet2 = Instantiate(bulletPrefab, projectileSpawn.transform.position, transform.rotation);
                bullet2.tag = "Enemy Bullet";
                Rigidbody bullet2rb = bullet2.GetComponent<Rigidbody>();
                bullet2rb.AddForce((projectileSpawn.transform.forward + projectileSpawn.transform.right).normalized * 300f, ForceMode.Impulse);

                GameObject bullet3 = Instantiate(bulletPrefab, projectileSpawn.transform.position, transform.rotation);
                bullet3.tag = "Enemy Bullet";
                Rigidbody bullet3rb = bullet3.GetComponent<Rigidbody>();
                bullet3rb.AddForce((projectileSpawn.transform.forward - projectileSpawn.transform.right).normalized * 300f, ForceMode.Impulse);

                nextFire = Time.time + fireRate;
            }

            if (randAttack == 2 && Time.time > nextFire && dist <= 25f)
            {
                //Cannons
                //Left cannon
                if (projectileSpawn.transform.localRotation.eulerAngles.y <= 315 && projectileSpawn.transform.localRotation.eulerAngles.y >= 225)
                {
                    GameObject cannonball1 = Instantiate(cannonballPrefab, cannonLeft1.transform.position, transform.rotation);
                    cannonball1.tag = "Enemy Cannonball";
                    cannonball1.GetComponent<AudioSource>().Play();
                    Rigidbody cannonball1rb = cannonball1.GetComponent<Rigidbody>();
                    cannonball1rb.AddForce(-transform.right * 500f, ForceMode.Impulse);

                    GameObject cannonball2 = Instantiate(cannonballPrefab, cannonLeft2.transform.position, transform.rotation);
                    cannonball2.tag = "Enemy Cannonball";
                    Rigidbody cannonball2rb = cannonball2.GetComponent<Rigidbody>();
                    cannonball2rb.AddForce(-transform.right * 500f, ForceMode.Impulse);
                }

                //Right cannon
                if (projectileSpawn.transform.localRotation.eulerAngles.y <= 135 && projectileSpawn.transform.localRotation.eulerAngles.y >= 45)
                {
                    GameObject cannonball3 = Instantiate(cannonballPrefab, cannonRight1.transform.position, transform.rotation);
                    cannonball3.tag = "Enemy Cannonball";
                    cannonball3.GetComponent<AudioSource>().Play();
                    Rigidbody cannonball3rb = cannonball3.GetComponent<Rigidbody>();
                    cannonball3rb.AddForce(transform.right * 500f, ForceMode.Impulse);

                    GameObject cannonball4 = Instantiate(cannonballPrefab, cannonRight2.transform.position, transform.rotation);
                    cannonball4.tag = "Enemy Cannonball";
                    Rigidbody cannonball4rb = cannonball4.GetComponent<Rigidbody>();
                    cannonball4rb.AddForce(transform.right * 500f, ForceMode.Impulse);
                }

                //Front cannon
                if (projectileSpawn.transform.localRotation.eulerAngles.y <= 45 && projectileSpawn.transform.localRotation.eulerAngles.y >= 0)
                {
                    GameObject cannonballFront = Instantiate(cannonballPrefab, cannonFront.transform.position, transform.rotation);
                    cannonballFront.tag = "Enemy Cannonball";
                    cannonballFront.GetComponent<AudioSource>().Play();
                    Rigidbody cannonballFrontrb = cannonballFront.GetComponent<Rigidbody>();
                    cannonballFrontrb.AddForce(transform.forward * 500f, ForceMode.Impulse);
                }

                if (projectileSpawn.transform.localRotation.eulerAngles.y <= 360 && projectileSpawn.transform.localRotation.eulerAngles.y >= 315)
                {
                    GameObject cannonballFront = Instantiate(cannonballPrefab, cannonFront.transform.position, transform.rotation);
                    cannonballFront.tag = "Enemy Cannonball";
                    cannonballFront.GetComponent<AudioSource>().Play();
                    Rigidbody cannonballFrontrb = cannonballFront.GetComponent<Rigidbody>();
                    cannonballFrontrb.AddForce(transform.forward * 500f, ForceMode.Impulse);
                }

                nextFire = Time.time + fireRate;
            }

        }
        else
        {
            rb.detectCollisions = false;
            boxCollider.enabled = false;
            GetComponent<FloatingGameEntityRealist>().enabled = false;

            if (!sinkPlayed)
            {
                sink.Play();
                sinkPlayed = true;
            }

            if (transform.position.y <= -10)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player Rock")
        {
            health -= 10;
            damage.PlayOneShot(damage.clip);
        }

        if (other.gameObject.tag == "Player Bullet")
        {
            health -= 10;
            damage.PlayOneShot(damage.clip);
        }

        if (other.gameObject.tag == "Player Cannonball")
        {
            health -= 20;
            damage.PlayOneShot(damage.clip);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bounds")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Booty")
        {
            var.booty -= 1;
        }
    }
}
