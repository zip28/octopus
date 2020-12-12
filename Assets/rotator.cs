using UnityEngine;

public class rotator : MonoBehaviour
{
    public Vector3 rotor = Vector3.up;
   
    void Update()
    {
        transform.eulerAngles += rotor;
    }
}
