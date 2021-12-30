using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorer : MonoBehaviour
{
    public octopus Player;
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "stick"){
            Player.score += 1;
        }
        Debug.Log("score+");
    }
}
