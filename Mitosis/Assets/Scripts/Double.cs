using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : MonoBehaviour
{
    public int doubles;
    private float velocity;
    public GameObject lazer;
    [SerializeField] GameObject projectile;
    [SerializeField] int TimeBetweenShots;
    [SerializeField] float shotCounter;
    [SerializeField] float lazerSpeedY = 5f;
    [SerializeField] float lazerSpeedX = 5f;
    [SerializeField] AudioClip lazerSound;
    [SerializeField] [Range(0, 10)] float lazerVolume = 0.75f;
    [SerializeField] Sprite off;
    [SerializeField] Sprite on;
    public float timer;
    public float atimer;
    public float btimer;
    [SerializeField] GameObject chipVFX;
    Vector2 frenpos;
    Vector2 mepos;
    Vector2 movedir;
    public bool angry;
    public int i;
    int ran = 0;
    float ranwait = 0;
    public bool sadness;
    public bool acheck;


    [SerializeField] float durationOfExplosion = 1.5f;
    public bool happy;
    public GameObject friend;
    
    // Start is called before the first frame update

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = off;
    }


    void Update()
    {
        Debug.Log("i is " + i);
        Debug.Log("angry is " + Singleton.cubeacount);



        int doubles = FindObjectsOfType<Double>().Length;
        timer += Time.deltaTime;
        Huddle();
        if (timer >= 1)
        {
            timer = 0f;
           
            if (doubles <= 70f)
            {
                Fire();
            }
        }
        if (happy == false)
        {
            Debug.Log("I am sad. I am sad, I am so very very sad and alone.");
            GetComponent<SpriteRenderer>().sprite = off;
        }
       Attack();
    }
    private void Attack()
    {
       
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 atpos = player.transform.position - transform.position;
        btimer += Time.deltaTime;
        
        {
            if (Singleton.cubeacount < i * 0.3333f)
            {
                ranwait += Time.deltaTime;
                if (ranwait > Random.Range(5, 10))
                {
                    ranwait = 0;
                    ran = Random.Range(1, 100);
                }
                if (ran > 80)
                {
                    angry = true;
                    if (acheck == false)
                    {
                        Singleton.cubeacount = Singleton.cubeacount + 1;
                        acheck = true;
                    }

                }
            }
            else
            {
                angry = false;
                if (acheck == true)
                {
                    Singleton.cubeacount = Singleton.cubeacount - 1;
                    acheck = false;
                }
                if (sadness == true)
                {
                    happy = false;
                    sadness = false;
                }
            }
           
            
        }
        
        if (happy == true && angry)
        {
         
            if (btimer >= 0.1)
            {
                btimer = 0f;
                GetComponent<Rigidbody2D>().AddForce(atpos);
                Debug.DrawRay(transform.position, (atpos), Color.blue, 0.25f);

            }
        }
    }
    private void OnTriggerEnter2D()
    {
        if (gameObject.tag == "Double")
        {
            happy = true;
            GetComponent<SpriteRenderer>().sprite = on;
        }
    }
    private void OnTriggerStay2D()
    {
        if (gameObject.tag == "Double")
        {
            happy = true;
            GetComponent<SpriteRenderer>().sprite = on;
        }
    }
    private void OnTriggerExit2D()
    {
        if (gameObject.tag == "Double" && angry == false)
        {
            happy = false;
            GetComponent<SpriteRenderer>().sprite = off;
        }
        else sadness = true;
    }
    private void Huddle()
    {
        
        if (happy == false)
        {
            atimer += Time.deltaTime;

            if (atimer >= 0.1)
            {
                atimer = 0f;
                Debug.DrawRay(transform.position, (movedir), Color.red, 0.25f);

            }
            Vector2 totpos = new Vector2(0, 0);
            Vector2 avpos = new Vector2(0, 0);
            GameObject[] friends = GameObject.FindGameObjectsWithTag("Double");

            for (  i = 0; i < friends.Length; i++)
            {
                Vector2 newDist = friends[i].transform.position;
                if (friends[i] != gameObject)
                {
                    totpos = totpos + newDist;
                    avpos = totpos / i;
                    friend = friends[i];

                    mepos = gameObject.transform.position;
                    movedir = avpos - mepos;
                    GetComponent<Rigidbody2D>().velocity = movedir;
                   
                   
                }
            }


        }

    }


    private void Fire()
    {
        lazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(1 * -lazerSpeedX, 1 * lazerSpeedX), Random.Range(1 * -lazerSpeedY, 1 * lazerSpeedY));
    }
}

