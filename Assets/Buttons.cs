using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public float horizontal;
    // Start is called before the first frame update
    public void Click2()
    {
        horizontal = 1f;
    }

    // Update is called once per frame
    public void Click1()
    {
        horizontal = -1f;
    }
    public void Out1()
    {
        if(horizontal != 1f) horizontal = 0;
    }
    public void Out2()
    {
        if(horizontal != -1f) horizontal = 0;
    }
}
