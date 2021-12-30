using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showMoneyAndScore : MonoBehaviour
{
    [SerializeField] Text score,money;
    private void Start() {
        Show();
    }
    public void Show()
    {
        if(PlayerPrefs.HasKey("BestScore")){
            score.text = "best score:"+PlayerPrefs.GetInt("BestScore").ToString();
        }else{
            score.text = "best score:0";
        }
        if(PlayerPrefs.HasKey("BestScore")){
            money.text = PlayerPrefs.GetInt("Money").ToString();
        }else{
            money.text = "0";
        }
    }
}
