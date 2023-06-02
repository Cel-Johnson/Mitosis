using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCell : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public GameObject cellSpawn;
    [SerializeField] float lazerSpeedY = 5f;
    [SerializeField] float lazerSpeedX = 5f;
    public GameObject[] doubles;
    int D;
    int i;
    public bool happy;
    public float[] doubleList;
    int e = 0;
    float distance;
    public float happyDist;
    public float attackTimer;
    Vector2 frenpos;
    Vector2 mepos;
    Vector2 movedir;
    int adjacentCellCounter;
    float ranwait = 0;
    public float movementTimer;
    public bool angry;
    int ran;
    public int angries;
    float spawnTimer = 0;
    public float timeBetweenSpawns;
    public int spawnmax;
    public Rigidbody rb;
    public float rotationalDamp = 0.5f;
    public GameObject aimer;
    public int spd;

    public int team;

    public ParticleSystem ps;

    public Color color;

    public int birthRate;

    // Start is called before the first frame update
    void Start()
    {
        ranwait = Random.Range(0, 5);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
     
        if(team == 1)
        {
            color = Color.green;
        }
        if (team == 2)
        {
            color = Color.blue;
        }
        if (team == 3)
        {
            color = Color.red;
        }
       

        ps.startColor = color;

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

        birthRate = Random.Range(1, 200);

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeBetweenSpawns)
        {
            if (doubles.Length < spawnmax && birthRate == 1)
            {
                birthRate = Random.Range(1, 50);
                cellSpawn = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                cellSpawn.GetComponent<BattleCell>().team = team;
                cellSpawn.GetComponent<Rigidbody>().velocity = new Vector2(Random.Range(1 * -lazerSpeedX, 1 * lazerSpeedX), Random.Range(1 * -lazerSpeedY, 1 * lazerSpeedY));
                spawnTimer = 0;
            }
        }

        for (D = 0; D < doubles.Length; D++)
        {
            distance = Vector3.Distance(transform.position, doubles[D].transform.position);
            doubleList[D] = distance;
        }
        happy = false;
        adjacentCellCounter = 0;
        for (e = 0; e < doubleList.Length; e++)
        {
            if (doubleList[e] < happyDist && doubleList[e] > 1)
            {
                adjacentCellCounter++;
                if (adjacentCellCounter >= doubleList.Length / 5)
                {
                    happy = true;
                }
            }
        }
        if (angry == false)
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

            attackTimer += Time.deltaTime;

            if (attackTimer >= 0.001)
            {
                attackTimer = 0f;
                Debug.DrawRay(transform.position, (avpos - mepos), Color.blue, 0.03f);

                Vector3 pos = new Vector3(avpos.x, avpos.y, 0) - transform.position;
                Quaternion rotation = Quaternion.LookRotation(pos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
                GetComponent<Rigidbody>().AddForce(aimer.transform.position - transform.position);
            }
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
        if (angry == true)
        {
            Vector3 pos = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);

            movementTimer += Time.deltaTime;

            if (movementTimer >= 0.01)
            {
                Debug.DrawRay(transform.position, (atpos), Color.red, 0.03f);

                movementTimer = 0f;
                GetComponent<Rigidbody>().AddForce(aimer.transform.position - transform.position);
            }
        }
    }
}
       
    

