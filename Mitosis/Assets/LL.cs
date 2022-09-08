using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LL : MonoBehaviour
{
    public static int ls;
  
    public int lidentity;
    // Start is called before the first frame update
    void Start()
    {
        ls++;
        lidentity = ls;
    }

    // Update is called once per frame
    void Update()
    {
       
       
       
        if (Input.GetKey(KeyCode.Mouse0) && lidentity == ls)
        {
            ls = ls - 1;
            Destroy(gameObject);
            
        }
    }
}
