using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Text moneyCount,scoreCount;
    public GameObject lose;
    public Text moneyShow,scoreShow;
    public int score;
    public bool CanDead = true;
    public stick_spawner spawner;
    public bool dead;
    public Joystick joystick;
    public bool canMove;
    private void Start() {
        target = gameObject.transform.position;
        Time.timeScale =1;
    }
    void Update()
    {
        if(health>6){
            health =6;
        }
        if((gameObject.transform.position.x <rightTop || Input.GetAxis("Horizontal")<0) && (gameObject.transform.position.x>leftTop || Input.GetAxis("Horizontal")>0)){
            gameObject.transform.position += (Vector3.right*Input.GetAxis("Horizontal")*speed*Time.deltaTime);
        }
        moneyCount.text = money.ToString();
        scoreCount.text = score.ToString();
        if(Input.GetKeyDown(KeyCode.W) && target.y < top && canMove){
            target = target+Vector3.up*range;
            bubbles.Play();
            lie = true;
            Invoke("Sheild",0.1f);
            canMove = false;
            
        }else if(Input.GetKeyDown(KeyCode.S) && target.y > down && canMove){
            target = target-Vector3.up*range;
            bubbles.Play();
            lie = true;
            Invoke("Sheild",0.1f);
            canMove =false;
        }else if(!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S)) {
            canMove =true;
        }
        target = new Vector3(gameObject.transform.position.x,target.y,target.z);
        gameObject.transform.position =  Vector3.Lerp(gameObject.transform.position,target,speedvertical*Time.deltaTime);
        if(health <= 0 && CanDead){
            Time.timeScale = 0;
            lose.SetActive(true);
            moneyShow.text = "your money: "+money.ToString();
            scoreShow.text = "your score: "+score.ToString();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            spawner.Stopper();
            dead = true;
        }
    }
    void Sheild(){
        lie = false;
    }
    private void OnMouseDown() {
        if(dead){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
