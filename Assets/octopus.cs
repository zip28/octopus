using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class octopus : MonoBehaviour
{
    public float speed;
    public float range;
    public float rightTop,leftTop;
    public float speedvertical;
    public Vector3 target;
    public float top,down;
    public int health =6;
    public ParticleSystem bubbles;
    public bool lie;
    public int money;
    public Text moneyCount;
    private void Start() {
        target = gameObject.transform.position;
    }
    void Update()
    {
        if((gameObject.transform.position.x <rightTop || Input.GetAxis("Horizontal")<0) && (gameObject.transform.position.x>leftTop || Input.GetAxis("Horizontal")>0)){
            gameObject.transform.position += (Vector3.right*Input.GetAxis("Horizontal")*speed);
        }
        moneyCount.text = money.ToString();
        if(Input.GetKeyDown(KeyCode.W) && target.y < top){
            target = target+Vector3.up*range;
            bubbles.Play();
            lie = true;
            Invoke("Sheild",0.1f);
            
        }
        if(Input.GetKeyDown(KeyCode.S)&& target.y > down){
            target = target-Vector3.up*range;
            bubbles.Play();
            lie = true;
            Invoke("Sheild",0.1f);
        }
        target = new Vector3(gameObject.transform.position.x,target.y,target.z);
        gameObject.transform.position =  Vector3.Lerp(gameObject.transform.position,target,speedvertical);
    }
    void Sheild(){
        lie = false;
    }

}
