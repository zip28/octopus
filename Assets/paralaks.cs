using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaks : MonoBehaviour
{
    public float speed;
    public float xfirst;
    public float xend;
    void Update()
    {
        gameObject.transform.position -= Vector3.right*speed*Time.deltaTime;
        if(gameObject.transform.position.x <= xend){
            gameObject.transform.position += Vector3.right*xfirst;
        }
    }
}
