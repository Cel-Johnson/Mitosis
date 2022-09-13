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
        
    }
    private void Awake()
    {
        ls++;
        lidentity = ls;
     
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && lidentity == 1)
        {
           
            Destroy(gameObject);
            ls--;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && lidentity != 1)

        {
            lidentity--;
        }
    }
}