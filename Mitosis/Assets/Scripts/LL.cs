using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RR : MonoBehaviour
{
    public static int ls;

    public GameObject lgoal;
   static float workscore;

    public int lidentity;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        ls++;
        lidentity = ls;
     
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && lidentity == 1)
        {
            workscore += Vector2.Distance(transform.position, lgoal.transform.position);
            Debug.Log(workscore);
            Destroy(gameObject);
            ls--;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1) && lidentity != 1)

        {
            lidentity--;
        }
    }
}