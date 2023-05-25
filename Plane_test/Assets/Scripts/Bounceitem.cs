using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounceitem : MonoBehaviour
{
    // Start is called before the first frame update


    Rigidbody2D bounce_rigid;
    void Start()
    {

        bounce_rigid = GetComponent<Rigidbody2D>();
        float randmX = Random.Range(-1f, 1f);
        float randmY = Random.Range(-1f, 1f);
        

        Vector2 nextDir=new Vector2(randmX, randmY);
        bounce_rigid.AddForce(nextDir*500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
