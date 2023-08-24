using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool isShaked = false;
    public IEnumerator CameraShaker(float duration,float magnitude) 
    {
        Vector3 camPos = transform.localPosition;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f,1f) * magnitude;
            transform.localPosition = new Vector3(x,y,camPos.z);
            elapsedTime += Time.deltaTime;

            yield return null;


            
        }

        transform.localPosition = camPos;

    }

    public void GetCameraShake() 
    {
        if(!isShaked) 
        {
            StartCoroutine(CameraShaker(0.22f,0.4f));
            isShaked = true;

        }
        

    }
} 
