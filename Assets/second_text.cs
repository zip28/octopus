using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class second_text : MonoBehaviour
{
    public Text text2;
    void Update()
    {
       gameObject.GetComponent<Text>().text = text2.text;
    }
}
