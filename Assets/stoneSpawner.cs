using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneSpawner : MonoBehaviour
{
    [SerializeField] GameObject stone;
    [SerializeField] Transform screenBorder;
    [SerializeField] float time;
    [SerializeField] octopus octopus;
    [SerializeField] int score;
    [SerializeField] Transform canvas;
    [SerializeField] GameObject instantiatedStone;
    private void Start() {
        StartCoroutine("SpawnStone");
    }
    IEnumerator SpawnStone(){
        yield return new WaitForSeconds(time);
        if(octopus.score > score){
            instantiatedStone = Instantiate(stone,new Vector3(Random.Range(screenBorder.position.x,transform.position.x),transform.position.y,0),Quaternion.identity,canvas);
            instantiatedStone.GetComponent<Rigidbody2D>().AddForce(Vector2.up*3f,ForceMode2D.Impulse);
        }
        StartCoroutine("SpawnStone");
    }
}
