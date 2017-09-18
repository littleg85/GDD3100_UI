using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour {

    private GameLogic gameLogic;
    private Rigidbody rb;
    private Variables var;
    public GameObject shadow;
    public bool capsize = false;

    //Weapons
    public GameObject rockPrefab;
    public GameObject bulletPrefab;
    public GameObject cannonballPrefab;
    private float nextFire = 0.0f;

    //Health
    public int health;

    //Audio
    public AudioSource damage;
    public AudioSource deadMen;
    public AudioSource win;
    private bool deadMenPlayed = false;
    private bool winPlayed = false;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        var = GameObject.Find("Variables").GetComponent<Variables>();
        gameLogic = GameObject.Find("GameUI").GetComponent<GameLogic>();

        //Hide children
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);

        //Health
        if (var.healthLevel == 0)
        {
            health = 20;
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if (var.healthLevel == 1)
        {
            health = 50;
            transform.GetChild(1).gameObject.SetActive(true);
        }

        if (var.healthLevel == 2)
        {
            health = 100;
            transform.GetChild(2).gameObject.SetActive(true);
        }

        //Attack
        if (var.attackLevel == 0)
        {
        }

        if (var.attackLevel == 1)
        {
        }

        if (var.attackLevel == 2)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {

        //Hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (health > 0 && !capsize)
        {
            //Movement
            if (Input.GetKey(KeyCode.W))
            {
                //rb.velocity += transform.forward * var.speed;
                rb.AddForce(transform.forward * var.speed * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.S))
            {
                //rb.velocity -= transform.forward * var.speed;
                rb.AddForce(-transform.forward * var.speed * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-transform.up * var.turnSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.up * var.turnSpeed * Time.deltaTime);
            }

            //If boat is flipped, reset game.
            if (transform.rotation.eulerAngles.z >= 170f && transform.rotation.eulerAngles.z <= 190f)
            {
                capsize = true;
                StartCoroutine(Capsize());
                if (!deadMenPlayed)
                {
                    deadMen.Play();
                    deadMenPlayed = true;
                }
            }

            //Play win sound
            if (gameLogic.gameWon)
            {
                if (!winPlayed)
                {
                    win.Play();
                    winPlayed = true;
                }
            }
        }
        else
        {
            //Play die sound and restart
            GetComponent<FloatingGameEntityRealist>().enabled = false;
            StartCoroutine(Sunk());
            if (!deadMenPlayed)
            {
                deadMen.Play();
                deadMenPlayed = true;
            }
        }
    }


    private void FixedUpdate()
    {

        if (health > 0)
        {

            //Projectiles
            if (Input.GetMouseButton(0) && Time.time > nextFire)
            {
                //Rock
                if (var.attackLevel == 0)
                {
                    GameObject rock = Instantiate(rockPrefab, GameObject.Find("playerRock").transform.position, transform.rotation);
                    rock.tag = "Player Rock";
                    Rigidbody rockrb = rock.GetComponent<Rigidbody>();
                    rockrb.AddForce(transform.up * 300f, ForceMode.Impulse);
                    rockrb.AddForce(shadow.transform.forward * 150f, ForceMode.Impulse);
                }

                //Guns
                if (var.attackLevel == 1)
                {
                    GameObject bullet1 = Instantiate(bulletPrefab, GameObject.Find("playerGuns").transform.position, transform.rotation);
                    bullet1.tag = "Player Bullet";
                    Rigidbody bullet1rb = bullet1.GetComponent<Rigidbody>();
                    bullet1rb.AddForce(shadow.transform.forward * 300f, ForceMode.Impulse);

                    GameObject bullet2 = Instantiate(bulletPrefab, GameObject.Find("playerGuns").transform.position, transform.rotation);
                    bullet2.tag = "Player Bullet";
                    Rigidbody bullet2rb = bullet2.GetComponent<Rigidbody>();
                    bullet2rb.AddForce((shadow.transform.forward + shadow.transform.right).normalized * 300f, ForceMode.Impulse);

                    GameObject bullet3 = Instantiate(bulletPrefab, GameObject.Find("playerGuns").transform.position, transform.rotation);
                    bullet3.tag = "Player Bullet";
                    Rigidbody bullet3rb = bullet3.GetComponent<Rigidbody>();
                    bullet3rb.AddForce((shadow.transform.forward - shadow.transform.right).normalized * 300f, ForceMode.Impulse);
                }

                //Cannons
                if (var.attackLevel == 2)
                {
                    //Left cannon
                    if (Camera.main.transform.localRotation.eulerAngles.y > 180 && Camera.main.transform.localRotation.eulerAngles.y <= 315)
                    {
                        GameObject cannonball1 = Instantiate(cannonballPrefab, GameObject.Find("cannonLeft1").transform.position, transform.rotation);
                        cannonball1.tag = "Player Cannonball";
                        cannonball1.GetComponent<AudioSource>().Play();
                        Rigidbody cannonball1rb = cannonball1.GetComponent<Rigidbody>();
                        cannonball1rb.AddForce(-transform.right * 500f, ForceMode.Impulse);

                        GameObject cannonball2 = Instantiate(cannonballPrefab, GameObject.Find("cannonLeft2").transform.position, transform.rotation);
                        cannonball2.tag = "Player Cannonball";
                        Rigidbody cannonball2rb = cannonball2.GetComponent<Rigidbody>();
                        cannonball2rb.AddForce(-transform.right * 500f, ForceMode.Impulse);
                    }

                    //Right cannon
                    if (Camera.main.transform.localRotation.eulerAngles.y >= 45 && Camera.main.transform.localRotation.eulerAngles.y < 180)
                    {
                        GameObject cannonball3 = Instantiate(cannonballPrefab, GameObject.Find("cannonRight1").transform.position, transform.rotation);
                        cannonball3.tag = "Player Cannonball";
                        cannonball3.GetComponent<AudioSource>().Play();
                        Rigidbody cannonball3rb = cannonball3.GetComponent<Rigidbody>();
                        cannonball3rb.AddForce(transform.right * 500f, ForceMode.Impulse);

                        GameObject cannonball4 = Instantiate(cannonballPrefab, GameObject.Find("cannonRight2").transform.position, transform.rotation);
                        cannonball4.tag = "Player Cannonball";
                        Rigidbody cannonball4rb = cannonball4.GetComponent<Rigidbody>();
                        cannonball4rb.AddForce(transform.right * 500f, ForceMode.Impulse);
                    }

                    //Front cannon
                    if (Camera.main.transform.localRotation.eulerAngles.y >= 0 && Camera.main.transform.localRotation.eulerAngles.y <= 45)
                    {
                        GameObject cannonballFront = Instantiate(cannonballPrefab, GameObject.Find("cannonFront").transform.position, transform.rotation);
                        cannonballFront.tag = "Player Cannonball";
                        cannonballFront.GetComponent<AudioSource>().Play();
                        Rigidbody cannonballFrontrb = cannonballFront.GetComponent<Rigidbody>();
                        cannonballFrontrb.AddForce(transform.forward * 500f, ForceMode.Impulse);
                    }
                    if (Camera.main.transform.localRotation.eulerAngles.y >= 315 && Camera.main.transform.localRotation.eulerAngles.y <= 360)
                    {
                        GameObject cannonballFront = Instantiate(cannonballPrefab, GameObject.Find("cannonFront").transform.position, transform.rotation);
                        cannonballFront.tag = "Player Cannonball";
                        cannonballFront.GetComponent<AudioSource>().Play();
                        Rigidbody cannonballFrontrb = cannonballFront.GetComponent<Rigidbody>();
                        cannonballFrontrb.AddForce(transform.forward * 500f, ForceMode.Impulse);
                    }


                }

                nextFire = Time.time + var.fireRate;
            }

            if (Input.GetMouseButton(1) && Time.time > nextFire)
            {
                if (var.attackLevel == 2)
                {
                    GameObject bullet1 = Instantiate(bulletPrefab, GameObject.Find("playerGuns").transform.position, transform.rotation);
                    bullet1.tag = "Player Bullet";
                    Rigidbody bullet1rb = bullet1.GetComponent<Rigidbody>();
                    bullet1rb.AddForce(shadow.transform.forward * 300f, ForceMode.Impulse);

                    GameObject bullet2 = Instantiate(bulletPrefab, GameObject.Find("playerGuns").transform.position, transform.rotation);
                    bullet2.tag = "Player Bullet";
                    Rigidbody bullet2rb = bullet2.GetComponent<Rigidbody>();
                    bullet2rb.AddForce((shadow.transform.forward + shadow.transform.right).normalized * 300f, ForceMode.Impulse);

                    GameObject bullet3 = Instantiate(bulletPrefab, GameObject.Find("playerGuns").transform.position, transform.rotation);
                    bullet3.tag = "Player Bullet";
                    Rigidbody bullet3rb = bullet3.GetComponent<Rigidbody>();
                    bullet3rb.AddForce((shadow.transform.forward - shadow.transform.right).normalized * 300f, ForceMode.Impulse);

                    nextFire = Time.time + var.fireRate;
                }
            }

            ////Controller Projectiles
            //if (Input.GetAxis("DPad Horizontal") == 1 && Time.time > nextFire)
            //{
            //    GameObject rock = Instantiate(rockPrefab, new Vector3(transform.position.x + 1, transform.position.y + 4, transform.position.z + 1), transform.rotation);
            //    Rigidbody rockrb = rock.GetComponent<Rigidbody>();
            //    rockrb.AddForce(new Vector3(1, 2, 0) * 150f, ForceMode.Impulse);
            //    nextFire = Time.time + var.fireRate;
            //}

            //if (Input.GetAxis("DPad Horizontal") == -1 && Time.time > nextFire)
            //{
            //    GameObject rock = Instantiate(rockPrefab, new Vector3(transform.position.x - 1, transform.position.y + 4, transform.position.z + 1), transform.rotation);
            //    Rigidbody rockrb = rock.GetComponent<Rigidbody>();
            //    rockrb.AddForce(new Vector3(-1, 2, 0) * 150f, ForceMode.Impulse);
            //    nextFire = Time.time + var.fireRate;
            //}

            //if (Input.GetAxis("DPad Vertical") == 1 && Time.time > nextFire)
            //{
            //    GameObject rock = Instantiate(rockPrefab, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z + 5), transform.rotation);
            //    Rigidbody rockrb = rock.GetComponent<Rigidbody>();
            //    rockrb.AddForce(new Vector3(0, 2, 1) * 150f, ForceMode.Impulse);
            //    nextFire = Time.time + var.fireRate;
            //}

            //if (Input.GetAxis("DPad Vertical") == -1 && Time.time > nextFire)
            //{
            //    GameObject rock = Instantiate(rockPrefab, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z - 3), transform.rotation);
            //    Rigidbody rockrb = rock.GetComponent<Rigidbody>();
            //    rockrb.AddForce(new Vector3(0, 2, -1) * 150f, ForceMode.Impulse);
            //    nextFire = Time.time + var.fireRate;
            //}
        }
    }

    IEnumerator Capsize()
    {
        yield return new WaitForSeconds(5.0f);
        var.booty = 10000;
        SceneManager.LoadScene("menu"); //Restart game after 3 seconds.
    }

    IEnumerator Sunk()
    {
        yield return new WaitForSeconds(5.0f);
        var.booty = 10000;
        SceneManager.LoadScene("menu"); //Restart game after 3 seconds.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (health > 0)
        {
            if (other.gameObject.tag == "Enemy Rock")
            {
                health -= 10;
                damage.Play();
            }

            if (other.gameObject.tag == "Enemy Bullet")
            {
                health -= 10;
                damage.Play();
            }

            if (other.gameObject.tag == "Enemy Cannonball")
            {
                health -= 20;
                damage.Play();
            }
        }
    }
}
