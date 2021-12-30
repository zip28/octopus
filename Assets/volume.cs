using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    [SerializeField] Sprite on,off;
    public bool sound;
    public void Change() {
        sound = !sound;
        if(sound){
            gameObject.GetComponent<Image>().sprite = on;
        }else{
            gameObject.GetComponent<Image>().sprite = off;
        }
    }
}
