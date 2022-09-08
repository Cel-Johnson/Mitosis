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
    public float timer;
    public float upfreq;
    public float sC;
    public float sss;
    // Start is called before the first frame update
    void Start()
    {
        big = true;
        sss = sC * Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
       
        scaleChange = new Vector3(sss, sss, sss);

        timer += Time.deltaTime;
        if (timer >= upfreq)
        {
            timer = 0;
            if (sizegot == false)
            {
                sizegot = true;
                if (big == true)
                {
                    ran = Random.Range(4, 6);

                }
                else
                {
                    ran = 0;
                }

                sizegoal = new Vector3(ran, ran, ran);
            }
            if (sizegot == true && me.transform.localScale != new Vector3(0, 0, 0))
            {
                if (x < ran + sC && x > ran - sC)
                {
                    sizegot = false;
                    sss = sC * Random.Range(0.5f, 2f);
                    if (big == true)
                    {
                        big = false;
                    }
                    else
                    {
                        big = true;
                    }
                }
                x = me.transform.localScale.x;
                if (x < ran)
                {
                    me.transform.localScale += scaleChange;
                }
                if (x > ran)
                {
                    me.transform.localScale -= scaleChange;
                }

            }
            if (Input.GetKey(KeyCode.Space))

            {
                if (big == false)
                {
                    big = true;
                    sizegot = false;
                    Debug.Log(1 - x);
                }
            }
        }
    }

}
