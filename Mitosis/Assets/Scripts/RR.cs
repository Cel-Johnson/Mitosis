using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LL : MonoBehaviour
{
    public static int rs;
    public GameObject rgoal;

    public int ridentity;

    static float workscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        rs++;
        ridentity = rs;
     
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ridentity == 1)
        {
            workscore += Vector2.Distance(transform.position, rgoal.transform.position);
            Debug.Log(workscore);
            Destroy(gameObject);
            rs--;

        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && ridentity != 1)

        {
            ridentity--;
        }
    }
}