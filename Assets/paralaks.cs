using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaks : MonoBehaviour
{
    public float speed;
    public float xfirst;
    public float xend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right*speed;
        if(gameObject.transform.position.x <= xend){
            gameObject.transform.position += Vector3.right*xfirst;
        }
    }
}
