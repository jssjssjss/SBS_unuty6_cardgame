using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject astroid;
    public GameObject[] spawn_pos;
    
    float cur_timer = 0;
    float spawn_delay = .7f;

   
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;
        //cur_timer += Time.deltaTime; // À§¶û °°Àº°Å

        if(cur_timer> spawn_delay)
        {
            int randnum = Random.Range(0, 4);
            GameObject astroid_info
                = Instantiate(astroid, spawn_pos[randnum].transform.position, spawn_pos[randnum].transform.rotation);

            Rigidbody2D astroid_rigid = astroid_info.GetComponent<Rigidbody2D>();
            astroid_rigid.AddForce(Vector2.down * 3, ForceMode2D.Impulse);
            cur_timer = 0;

        }



       
    }
}
