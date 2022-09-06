using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Vector2 plapospub;

    public Vector2 plapos;

    void Start()
    {

    }


    void Update()
    {

        plapos = transform.position;
        plapospub = plapos;

        if (Input.GetKey(KeyCode.UpArrow))

        {
            GetComponent<Rigidbody>().AddForce(new Vector2(0, 10));
        }
        if (Input.GetKey(KeyCode.DownArrow))

        {
            GetComponent<Rigidbody>().AddForce(new Vector2(0, -10));

        }
        if (Input.GetKey(KeyCode.RightArrow))

        {
            GetComponent<Rigidbody>().AddForce(new Vector2(10, 0));

        }
        if (Input.GetKey(KeyCode.LeftArrow))

        {
            GetComponent<Rigidbody>().AddForce(new Vector2(-10, 0));

        }
    
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vel();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            vel();
        }
    }




    private void anvel()
    {
        Vector2 newVel = GetComponent<Rigidbody>().velocity;
        newVel.x = Mathf.Clamp(newVel.x, -0, 0);
        GetComponent<Rigidbody>().velocity = newVel;
        Vector2 newfall = GetComponent<Rigidbody>().velocity;
        newfall.y = Mathf.Clamp(newfall.y, -0, 0);
        GetComponent<Rigidbody>().velocity = newfall;
    }

    public void vel()
    {
        Vector2 newVel = GetComponent<Rigidbody>().velocity;
        newVel.x = Mathf.Clamp(newVel.x, -10, 10);
        GetComponent<Rigidbody>().velocity = newVel;
        Vector2 newfall = GetComponent<Rigidbody>().velocity;
        newfall.y = Mathf.Clamp(newfall.y, -10, 10);
        GetComponent<Rigidbody>().velocity = newfall;
    }


}