using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShmove : MonoBehaviour
{
    public float btimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 atpos = player.transform.position - transform.position;
        btimer += Time.deltaTime;
        if (btimer >= 0.01)
        {
            btimer = 0f;
            GetComponent<Rigidbody2D>().AddForce(atpos);
            Debug.DrawRay(transform.position, (atpos), Color.yellow, 0.25f);

        }
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.drag = 10 - Vector2.Distance(player.transform.position, transform.position) ;
        if (rb.drag>5)
        {
            rb.drag = 5;
        }
        if(rb.drag<1)
        {
            rb.drag = 1;
        }
    }
}