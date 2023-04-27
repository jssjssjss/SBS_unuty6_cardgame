using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public class GameManager : MonoBehaviour
{

    public GameObject[] card;
    
    public Sprite[] my_sprites;

    List<SpriteRenderer> card_renderer;
    List<String> list = new List<String>();
    List<int> num = new List<int>();
    List<String> sh = new List<String>();


   


    // Start is called before the first frame update
    void Start()
    {



        for (int i = 0; i < 4; i++)
        {

            card_renderer[i] = card[i].GetComponent<SpriteRenderer>();
            card_renderer[i].sprite=my_sprites[i];

            list.Add(card_renderer[i].sprite.name);

            Debug.Log("i는" + i);

        }

        for (int i = 0; i < list.Count-1; i++)
        {
            num.Add(int.Parse(card_renderer[i].sprite.name.Substring(0, 2)));
            sh.Add(card_renderer[i].sprite.name.Substring(2, 1));


        }




        //num.Add(int.Parse(card1_renderer.sprite.name.Substring(0, 2)));
        //num.Add(int.Parse(card2_renderer.sprite.name.Substring(0, 2)));
        //num.Add(int.Parse(card3_renderer.sprite.name.Substring(0, 2)));
        //num.Add(int.Parse(card4_renderer.sprite.name.Substring(0, 2)));
        //num.Add(int.Parse(card5_renderer.sprite.name.Substring(0, 2)));






        Debug.Log(num[0] + "여기여기여기여기여기여기여기여기여기여기여기여기여기여기여기여기여기" + sh[0]);



        
       
       

        


      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
