using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick_spawner : MonoBehaviour
{
    int rnd,lastrnd,obj;
    public float time;
    public GameObject stick;
    public GameObject monet;
    public GameObject health;
    public GameObject diamond;
    public float range;
    public float middle;
    public octopus Player;
    float speed;
    private void Start() {
        StartCoroutine(SpawnStick());
        speed = stick.GetComponent<stick>().speed;
    }
    IEnumerator SpawnStick(){
        yield return new WaitForSeconds(time);
        rnd = Random.Range(1,4);
        obj = Random.Range(1,18);
        if(rnd != 1){
            Instantiate(stick,gameObject.transform.position+ Vector3.up*range,Quaternion.identity,gameObject.transform);
        }
        if(rnd != 2){
            Instantiate(stick,gameObject.transform.position+ Vector3.up*range*2,Quaternion.identity,gameObject.transform);
        }
        if(rnd != 3 && rnd != 4){
            Instantiate(stick,gameObject.transform.position+ Vector3.up*+range*3,Quaternion.identity,gameObject.transform);
        }
        if (lastrnd == rnd && rnd == 2 && obj>1 && obj <6){
            Debug.Log("Monet!");
            Instantiate(monet,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime*middle/2+ Vector3.up*range*(Random.Range(0,2)*2+1),Quaternion.identity,gameObject.transform);
        }else if(lastrnd == rnd && rnd == 2 && obj> 7 && obj<15-Player.health){
            Instantiate(health,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime*middle/2+ Vector3.up*range*(Random.Range(0,2)*2+1),Quaternion.identity,gameObject.transform);
        }else if(lastrnd == rnd && rnd != 2 && obj>15 && obj <18){
            Instantiate(diamond,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime*middle/2+ Vector3.up*range*(Mathf.Abs( rnd*2-5)),Quaternion.identity,gameObject.transform);
        }
        if (lastrnd == rnd && rnd != 2 && obj>1 && obj <6){
            Debug.Log("Monet!");
            Instantiate(monet,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime*middle/2+ Vector3.up*range*2,Quaternion.identity,gameObject.transform);
        }else if(lastrnd == rnd && rnd != 2 && obj> 7 && obj<15-Player.health){
            Instantiate(health,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime*middle/2+ Vector3.up*range*2,Quaternion.identity,gameObject.transform);
        }
        lastrnd = rnd;
        StartCoroutine(SpawnStick());
    }
    public void Stopper(){
        for (int i = 0;i<gameObject.transform.childCount;i++){
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }
}
