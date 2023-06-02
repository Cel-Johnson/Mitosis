using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rspawn : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public GameObject lazer;
    public float timer;
    public float stime;
    public float ran;
    // Start is called before the first frame update
    void Start()
    {
        ran = stime;
        ran = stime * Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >=(ran))
        {
            timer = 0;
            ran = stime;
            ran = stime * Random.Range(0.5f, 1.5f);
            lazer = Instantiate(projectile, transform.position , Quaternion.identity) as GameObject;

        }
    }
}
