using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float cur_timer;
    float destroy_timer = 5;
   
    

    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        cur_timer =cur_timer+ Time.deltaTime;

        if (cur_timer > destroy_timer)
        {

            gameObject.SetActive(false);
            cur_timer = 0;

        }

    }
}