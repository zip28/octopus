using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public float speed =1;
    public float lifetime;
    public bool move;
    public int damage = 1;
    public bool giveScore = true;
    void Update()
    {
        if(move){
            gameObject.transform.position += Vector3.left*speed*Time.deltaTime;
        }
        Invoke("DeleteStick",lifetime);
    }
    void DeleteStick(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            
            if(!move && other.gameObject.GetComponent<octopus>().lie && other.gameObject.GetComponent<octopus>().health<3){
            }else{
                other.gameObject.GetComponent<octopus>().health -= damage;
            }
        }
        if(other.gameObject.tag == "Scorer" && giveScore){
            GetComponentInParent<stick_spawner>().Player.score += 1;
        }
    }
}
