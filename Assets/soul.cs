using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soul : MonoBehaviour
{
    public int number;
    public octopus player;
    public Sprite full,half,empty;
    public SpriteRenderer view;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health >= number*2){
            view.sprite = full;
        }
        if(player.health == number*2-1){
            view.sprite = half;
        }
        if(player.health < number*2-1){
            view.sprite = empty;
        }
    }
}
