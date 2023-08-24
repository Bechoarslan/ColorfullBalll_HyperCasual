using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlider : MonoBehaviour
{
    [SerializeField] private Vector3 pos1;
    [SerializeField] private Vector3 pos2;
    [SerializeField] private float speed;

    private void LateUpdate() 
    {
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(pos1,pos2,Mathf.PingPong(Time.time * speed,1f));
    }
}
