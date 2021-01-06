using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float speed =1;
    public float lifetime;
    private void Start() {
    }
    void Update()
    {
        gameObject.transform.position += Vector3.left*speed*Time.deltaTime;
        Invoke("DeleteHealth",lifetime);
    }
    void DeleteHealth(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<octopus>().health += 2;
            Destroy(gameObject);
        }
    }
}
