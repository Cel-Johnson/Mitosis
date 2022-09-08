using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lspawn : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public GameObject lazer;
    public float timer;
    public float stime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= stime)
        {
            timer = 0;
            lazer = Instantiate(projectile, transform.position , Quaternion.identity) as GameObject;

        }
    }
}
