using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBanner : MonoBehaviour
{
    private static SingletonBanner singletonObject = null;

    private void Awake() 
    { if(singletonObject == null) 
    {
        singletonObject = this;
        DontDestroyOnLoad(this);
    }
    else if(this != gameObject)
    {
        Destroy(gameObject);
    
    }
        
    }


}
