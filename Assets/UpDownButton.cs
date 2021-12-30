using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownButton : MonoBehaviour
{
    [SerializeField] int number;
    [SerializeField] octopus octopus;
    public void Move()
    {
        if(octopus.pose < number){
            octopus.MoveUp();
        }
        if(octopus.pose > number){
            octopus.MoveDown();
        }
    }
}
