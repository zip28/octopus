using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobPoser : MonoBehaviour
{
    [SerializeField] Transform buttonUp, buttonMiddle, buttonDown;
    [SerializeField] Transform leftUpAngle, rightDownAngle;
    private Vector3 _scale;
    void Start()
    {
        buttonUp.position = new Vector3((rightDownAngle.position.x + leftUpAngle.position.x)/2,(rightDownAngle.position.y + leftUpAngle.position.y * 2)/3,buttonUp.position.z);
        buttonMiddle.position = new Vector3((rightDownAngle.position.x + leftUpAngle.position.x)/2,(rightDownAngle.position.y + leftUpAngle.position.y)/2,buttonMiddle.position.z);
        buttonDown.position = new Vector3((rightDownAngle.position.x + leftUpAngle.position.x)/2,(rightDownAngle.position.y * 2 + leftUpAngle.position.y)/3,buttonDown.position.z);
        _scale = new Vector3((rightDownAngle.position.x - leftUpAngle.position.x) / 2,(leftUpAngle.position.y - rightDownAngle.position.y)/ 6,1);
        buttonDown.localScale = _scale;
        buttonMiddle.localScale = _scale;
        buttonUp.localScale = _scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
