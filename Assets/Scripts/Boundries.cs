using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
    [SerializeField] private Transform vectorLeft;
    [SerializeField] private Transform vectorRight;
    [SerializeField] private Transform vectorBack;
    [SerializeField] private Transform vectorForward;

    private void LateUpdate() 
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x,vectorLeft.position.x,vectorRight.position.x);
        viewPos.z = Mathf.Clamp(viewPos.z,vectorBack.position.z,vectorForward.position.z);
        transform.position = viewPos;
        
    }
}
