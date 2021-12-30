using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class octopus : MonoBehaviour
{
    public float speed;
    public float range;
    [SerializeField] Transform screenRange1,screenRange2;
    public float rightTop,leftTop;
    public float speedvertical;
    public Vector3 target;
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
    public int pose = 1;
    public bool test;
    public Buttons joystick;
    public float time;
    
    private void Start() {
        target = gameObject.transform.position;
        Time.timeScale =1;
        leftTop = screenRange1.position.x+1.5f;
        rightTop = screenRange2.position.x-1.5f;
        if(PlayerPrefs.HasKey("Money")){
            money = PlayerPrefs.GetInt("Money");
        }
    }
    public void MoveUp(){
        target = target+Vector3.up*range;
        bubbles.Play();
        lie = true;
        Invoke("Sheild",0.1f);
        pose += 1;
    }
    public void MoveDown()
    {
        target = target-Vector3.up*range;
        bubbles.Play();
        lie = true;
        Invoke("Sheild",0.1f);
        pose -= 1;
    }
    void Update()
    {
        time += Time.deltaTime;
        
        if(dead && Input.touchCount>0 || dead&&Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(health>6 && !test){
            health =6;
        }
        if((gameObject.transform.position.x <rightTop || joystick.horizontal<0) && (gameObject.transform.position.x>leftTop || joystick.horizontal > 0)){
            gameObject.transform.position += (Vector3.right*joystick.horizontal*speed*Time.deltaTime);
        }
        moneyCount.text = money.ToString();
        scoreCount.text = score.ToString();
        
        target = new Vector3(gameObject.transform.position.x,target.y,target.z);
        gameObject.transform.position =  Vector3.Lerp(gameObject.transform.position,target,speedvertical*Time.deltaTime);
        if(health <= 0 && CanDead){
            Die();
        }
    }
    void Sheild(){
        lie = false;
    }
    private void Die(){
        Time.timeScale = 0;
        PlayerPrefs.SetInt("Money",money);
        if(PlayerPrefs.HasKey("BestScore")){
            if(score>PlayerPrefs.GetInt("BestScore"))
                PlayerPrefs.SetInt("BestScore",score);
        }else{
            PlayerPrefs.SetInt("BestScore",score);
        }
        lose.SetActive(true);
        moneyShow.text = "your money: "+money.ToString();
        scoreShow.text = "your score: "+score.ToString();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        spawner.Stopper();
        dead = true;
    }
}
