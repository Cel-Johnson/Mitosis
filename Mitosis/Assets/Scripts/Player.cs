using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float wel;
   public int apple = 10;
    void Start()
    {

    }
    void Update()
    {
        wel += Time.deltaTime;

        if (wel >= 0.01f)
        {
            wel = 0;
            if (Input.GetKey(KeyCode.W))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(0, apple));
            }
            if (Input.GetKey(KeyCode.S))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(0, -apple));

            }
            if (Input.GetKey(KeyCode.D))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(apple, 0));

            }
            if (Input.GetKey(KeyCode.A))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(-apple, 0));

            }
            if (Input.GetKey(KeyCode.Space))

            {
                apple += 1; 

            }
            vel();
        }
    }
    public void vel()
    {
        Vector2 newVel = GetComponent<Rigidbody>().velocity;
        newVel.x = Mathf.Clamp(newVel.x, -apple, apple);
        GetComponent<Rigidbody>().velocity = newVel;
        Vector2 newfall = GetComponent<Rigidbody>().velocity;
        newfall.y = Mathf.Clamp(newfall.y, -apple, apple);
        GetComponent<Rigidbody>().velocity = newfall;
    }


}