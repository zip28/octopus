using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScemeLoader : MonoBehaviour
{
    public void GameLoad(){
        SceneManager.LoadScene("game");
    }
}
