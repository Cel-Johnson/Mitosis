using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public GameObject lazer;
    [SerializeField] float lazerSpeedY = 5f;
    [SerializeField] float lazerSpeedX = 5f;
    public GameObject[] doubles;
    public int D;
    public int i;
    public bool happy;
    public float[] doubleList;
    public int e = 0;
    public float distance;
    public float happyDist;
    public float atimer;
    Vector2 frenpos;
    Vector2 mepos;
    Vector2 movedir;
   public int had;
    float ranwait = 0;
    public float btimer;
    public bool angry;
    public int ran;
    public int angries;
    public float dietimer = 0;
    public float incrincr;
    public  int spawnmax;
    public Rigidbody rb;
    public float rotationalDamp = 0.5f;
    public GameObject aimer;
    public int spd;
    public bool swarm = false;
    // Start is called before the first frame update
    void Start()
    {
        ranwait = Random.Range(0, 5);
    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 atpos = player.transform.position - transform.position;
        Vector2 newVel = GetComponent<Rigidbody>().velocity;
        newVel.x = Mathf.Clamp(newVel.x, -spd, spd);
        GetComponent<Rigidbody>().velocity = newVel;
        Vector2 newfall = GetComponent<Rigidbody>().velocity;
        newfall.y = Mathf.Clamp(newfall.y, -spd, spd);
        GetComponent<Rigidbody>().velocity = newfall;
        doubles = GameObject.FindGameObjectsWithTag("Double");
        doubleList = new float[doubles.Length];
        dietimer += Time.deltaTime;
        if (dietimer >= incrincr)
        {
            spawnmax += 1;
            dietimer = 0;
        }
        if (doubles.Length < spawnmax)
        {
            lazer = Instantiate(projectile, transform.position * Random.Range(-2, 2), Quaternion.identity) as GameObject;
            lazer.GetComponent<Rigidbody>().velocity = new Vector2(Random.Range(1 * -lazerSpeedX, 1 * lazerSpeedX), Random.Range(1 * -lazerSpeedY, 1 * lazerSpeedY));
        }
        for (D = 0; D < doubles.Length; D++)
        {
            distance = Vector3.Distance(transform.position, doubles[D].transform.position);
            doubleList[D] = distance;
        }
        happy = false;
        had = 0;
        for (e = 0; e < doubleList.Length; e++)
        {
            if (doubleList[e] < happyDist && doubleList[e] > 1)
            {
                had ++;
                if(had >= doubleList.Length/5)
                {
                    happy = true;
                }
            }
        }
        if ( angry == false)
        {
           
            Vector2 totpos = new Vector2(0, 0);
            Vector2 avpos = new Vector2(0, 0);
            GameObject[] friends = GameObject.FindGameObjectsWithTag("Double");
            for (i = 0; i < friends.Length; i++)
            {
                Vector2 newDist = friends[i].transform.position;
                if (friends[i] != gameObject)
                {
                    totpos = totpos + newDist;
                    avpos = totpos / i;
                    mepos = gameObject.transform.position;
                    
                }
            }
            if (i== friends.Length&& swarm == true)
            {
                avpos += avpos * 2;
               avpos += new Vector2(player.transform.position.x, player.transform.position.y);
                avpos = avpos / 4;
              
            }
            atimer += Time.deltaTime;

            if (atimer >= 0.001)
            {
                atimer = 0f;
                Debug.DrawRay(transform.position, (avpos-mepos), Color.red, 0.25f);
            }
            Vector3 pos = new Vector3(avpos.x,avpos.y,0) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
            GetComponent<Rigidbody>().AddForce(aimer.transform.position - transform.position);
            //rb.drag = 0.5f;
            
        }
        

        {
                ranwait += Time.deltaTime;
                if (ranwait > Random.Range(5, 20))
                {
                    ranwait = 0;
                   ran = Random.Range(1, 100);
                }
                if (ran > 50 && angries <= doubleList.Length * 0.33f)
                {
                    angry = true;
                    angries += 1;
                }
                else
                {
                    angry = false;
                    angries -= 1;
                }
        }
        if (angry == true )
        {
            Vector3 pos = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
            //rb.drag = 0.5f;
            btimer += Time.deltaTime;
            Debug.DrawRay(transform.position, (atpos), Color.blue, 0.25f);
            if (btimer >= 0.01)
              btimer = 0f;
                GetComponent<Rigidbody>().AddForce(aimer.transform.position - transform.position);
        }
        else
        {
           // rb.drag = 0.5f;
        }
    }
}

