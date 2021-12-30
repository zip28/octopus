using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundScale : MonoBehaviour
{
    [SerializeField] Transform obj;
    [SerializeField] Transform xScale1;
    [SerializeField] Transform xScale2;
    void Start()
    {
        obj.localScale = new Vector3(xScale1.position.x-xScale2.position.x,10f,1f);
        obj.position = new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,obj.transform.position.z);
    }
}
