using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public float speed =1;
    public float lifetime;
    public bool move;
    public int damage = 1;
    void Update()
    {
        if(move){
            gameObject.transform.position += Vector3.left*speed;
        }
        Invoke("DeleteStick",lifetime);
    }
    void DeleteStick(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("hit");
            
            if(!move && other.GetComponent<octopus>().lie && other.GetComponent<octopus>().health<3){
            }else{
                other.gameObject.GetComponent<octopus>().health -= damage;
            }
        }
    }
}
