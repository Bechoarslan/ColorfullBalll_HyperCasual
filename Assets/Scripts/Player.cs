using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private Touch touch;
    
    private Rigidbody rb;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] GameObject cam;
    [SerializeField] UIManager uIManager;
    [SerializeField] private GameObject vectorForward;
    [SerializeField] private GameObject vectorBack;
    [SerializeField] private GameObject[] fractureItems;
    [Range(20,100)]
    [SerializeField] int speedModifier;
    [SerializeField]private float forwardSpeed;
    private bool isHit;
    private bool isTouchControll;

    [SerializeField] private Sound soundManager;

    private int soundLimitCounter;

    

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        
        

    }

   
   public void Update()
    {
        
        if(Variables.firstTouch == 1 && Variables.cameraTouch == 1) 
        {
            transform.position += new Vector3(0,0, forwardSpeed * Time.deltaTime);
            
            vectorBack.transform.position += new Vector3(0,0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0,0, forwardSpeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);



        }
        
        if(Input.touchCount > 0) 
        {
            if(uIManager.RestartButton(isHit)) return;
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) 
            {
                if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))  
                {
                    if(!isTouchControll) 
                    { Variables.firstTouch = 1;
                        Variables.cameraTouch = 1;
                        uIManager.FirstTouch();
                        isTouchControll = true;

                    }



                }
                
            }

            else if(touch.phase == TouchPhase.Moved) 
            { 
                
                 if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))  
                {
                     if(isTouchControll) 
                    { rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime, transform.position.y, touch.deltaPosition.y * speedModifier * Time.deltaTime);
                       isTouchControll = true;

                    } 
                
                }

            }
            else if(touch.phase == TouchPhase.Ended) 
            {
                rb.velocity =  Vector3.zero;

            }
            

        }
        
    }

    private void OnCollisionEnter(Collision other) 
    {  if(other.gameObject.CompareTag("Obstacles")) 
      {
          cameraShake.GetCameraShake();
          gameObject.transform.GetChild(0).gameObject.SetActive(false);
          uIManager.GetWhiteEffect();
          soundManager.BlastSound();
          
          if(PlayerPrefs.GetInt("Vibration") == 1) 
          {
                Vibration.Vibrate(50);

          }
          else if (PlayerPrefs.GetInt("Vibration") == 2) 
          {

          }          

          foreach (GameObject fracture in fractureItems)
          {
             fracture.GetComponent<SphereCollider>().enabled = true;
             fracture.GetComponent<Rigidbody>().isKinematic = false;
          }
          isHit = true;
          uIManager.RestartButton(isHit);
          StartCoroutine(uIManager.OpenRestartScene());

          
          

      }

       if(other.gameObject.CompareTag("Untagged")) 
      {
        
        soundLimitCounter++;

      }
       if(other.gameObject.CompareTag("Untagged") && soundLimitCounter %  5 == 0) 
      {
            soundManager.TouchSound();

        }
        
    }
    


    
    

    
}
