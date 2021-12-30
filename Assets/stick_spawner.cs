using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick_spawner : MonoBehaviour
{
    int rnd,nextrnd,obj;
    public float time;
    public GameObject stick;
    public GameObject monet;
    public GameObject health;
    public GameObject diamond;
    public float range;
    public float middle;
    public octopus Player;
    [SerializeField] float speed,rangeBetween;
    [SerializeField] float speedPlusssing;
    private GameObject instantiatedStick;
    private GameObject instantiatedMonet;
    private GameObject instantiatedHealth;
    [SerializeField] AnimationCurve hardnessCurve;
        private void Start() {
        rnd = Random.Range(1,4);
        StartCoroutine(SpawnStick());
    }
    IEnumerator SpawnStick(){
        speed = hardnessCurve.Evaluate(Player.time);
        yield return new WaitForSeconds(time);
        nextrnd = Random.Range(1,4);
        obj = Random.Range(1,18);
        time = rangeBetween/speed;
        if(time > 0.75f){
        middle = rangeBetween/2;
        }
        if(rnd != 1){
            instantiatedStick = Instantiate(stick,gameObject.transform.position+ Vector3.up*range,Quaternion.identity,gameObject.transform);
            instantiatedStick.GetComponent<stick>().speed = speed;
        }
        if(rnd != 2){
            instantiatedStick = Instantiate(stick,gameObject.transform.position+ Vector3.up*range*2,Quaternion.identity,gameObject.transform);
            instantiatedStick.GetComponent<stick>().speed = speed;
        }
        if(rnd != 3 && rnd != 4){
            instantiatedStick = Instantiate(stick,gameObject.transform.position+ Vector3.up*+range*3,Quaternion.identity,gameObject.transform);
            instantiatedStick.GetComponent<stick>().speed = speed;
        }
        Invoke("SpawnBonus",time/2);
        
        StartCoroutine(SpawnStick());
    }
    public void Stopper(){
        for (int i = 0;i<gameObject.transform.childCount;i++){
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void SpawnBonus(){
        if (rnd  == nextrnd) Debug.Log("==");
        if (nextrnd == rnd && rnd == 2 && obj>1 && obj <6){
            instantiatedMonet = Instantiate(monet,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime + Vector3.up*range*(Random.Range(0,2)*2+1),Quaternion.identity,gameObject.transform);
            instantiatedMonet.GetComponent<monet>().speed = speed;
        }else if(nextrnd == rnd && rnd == 2 && obj> 7 && obj<15-Player.health){
            instantiatedHealth = Instantiate(health,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime + Vector3.up*range*(Random.Range(0,2)*2+1),Quaternion.identity,gameObject.transform);
            instantiatedHealth.GetComponent<health>().speed = speed;
        }else if(nextrnd == rnd && rnd != 2 && obj>15 && obj <18){
            instantiatedMonet = Instantiate(diamond,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime + Vector3.up*range*(Mathf.Abs( rnd*2-5)),Quaternion.identity,gameObject.transform);
            instantiatedMonet.GetComponent<monet>().speed = speed;
        }
        if (nextrnd == rnd && rnd != 2 && obj>1 && obj <6){
            instantiatedMonet = Instantiate(monet,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime + Vector3.up*range*2,Quaternion.identity,gameObject.transform);
            instantiatedMonet.GetComponent<monet>().speed = speed;
        }else if(nextrnd == rnd && rnd != 2 && obj> 7 && obj<15-Player.health){
            instantiatedHealth = Instantiate(health,gameObject.transform.position+Vector3.left*time*speed*Time.deltaTime + Vector3.up*range*2,Quaternion.identity,gameObject.transform);
            instantiatedHealth.GetComponent<health>().speed = speed;
        }
        rnd = nextrnd;
    }
}