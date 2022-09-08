using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeUI : MonoBehaviour
{
    public Vector3 sizegoal;
    public bool sizegot;
    public float sizem;
    public float gtime;
    public int ran;
    public float x;
    public Vector3 scaleChange;
    public GameObject me;
    public bool big;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.02f, 0.02f, 0.02f);
        x = me.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (sizegot == false)
        {
            sizegot = true;
            if(big==true)
            {
                ran = Random.Range(7, 10);

            }
            else
            {
                ran = 0;
            }
            
            sizegoal = new Vector3 (ran,ran,ran);
        }
        if (sizegot == true && me.transform.localScale != new Vector3(0, 0, 0))
        {
            if (x < ran + 0.1f && x > ran - 0.1f)
            {
                sizegot = false;
                if(big ==true)
                {
                    big = false;
                }
                else
                {
                    big = true;
                }
            }
            if (x < ran)
            {
                me.transform.localScale += scaleChange;
                x += 0.02f;
            }
            if (x > ran)
            {
                me.transform.localScale -= scaleChange;
                x -= 0.02f;
            }
           
        }
        if (Input.GetKey(KeyCode.Space))

        {
            if (big == false)
            {
                big = true;
                sizegot = false;
                Debug.Log(1-x);
            }
        }
        
    }

}
