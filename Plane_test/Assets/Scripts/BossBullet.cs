using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    float ed_time = 3;
    float st_time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        st_time = st_time + Time.deltaTime;
        if(st_time> ed_time)
        {
            Destroy(gameObject);
            st_time = 0;
        }


    }
}
