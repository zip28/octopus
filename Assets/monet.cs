using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monet : MonoBehaviour
{
    public float speed =1;
    public float lifetime;
    public int price = 1;
    void Update()
    {
        gameObject.transform.position += Vector3.left*speed;
        Invoke("DeleteMonet",lifetime);
    }
    void DeleteMonet(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<octopus>().money +=price;
        Destroy(gameObject);
    }
}
