using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
     
    
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject particle1;
    [SerializeField] private GameObject particle2;
    [SerializeField] private GameObject particle3;

    [SerializeField] private Sprite yellowSprite;
    [SerializeField] private Sprite greenSprite;

    [SerializeField] private GameObject item;
    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    [SerializeField] private GameObject item3;
   
    

    [SerializeField] private GameObject lock1;
    [SerializeField] private GameObject lock2;
    [SerializeField] private GameObject lock3;
    private UIManager uiManager;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("WhichParticle") == false) 
        {
            PlayerPrefs.SetInt("WhichParticle",0);
        }

        if(PlayerPrefs.GetInt("WhichParticle") == 0) 
        {
            OpenParticle();
        }
        if (PlayerPrefs.GetInt("WhichParticle") == 1)
        {
            OpenParticle2();
        }
        if (PlayerPrefs.GetInt("WhichParticle") == 2)
        {
            OpenParticle3();
        }
        if (PlayerPrefs.GetInt("WhichParticle") == 3)
        {
            OpenParticle4();
        }
        uiManager = GetComponent<UIManager>();
       if(PlayerPrefs.HasKey("lock1") == false) 
       {
         PlayerPrefs.SetInt("lock1",0);
       }
        if (PlayerPrefs.HasKey("lock2") == false)
        {
            PlayerPrefs.SetInt("lock2", 0);
        }
        if (PlayerPrefs.HasKey("lock3") == false)
        {
            PlayerPrefs.SetInt("lock3", 0);
        }

        if(PlayerPrefs.GetInt("lock1") == 1) 
        {
            lock1.SetActive(false);

        }
        if (PlayerPrefs.GetInt("lock2") == 1)
        {
            lock2.SetActive(false);

        }
        if (PlayerPrefs.GetInt("lock3") == 1)
        {
            lock3.SetActive(false);

        }




    }


    public void OpenParticle() 
   {
    particle.SetActive(true);
    particle1.SetActive(false);
    particle2.SetActive(false);
    particle3.SetActive(false);

    item.GetComponent<Image>().sprite = greenSprite;
    item1.GetComponent<Image>().sprite = yellowSprite;
    item2.GetComponent<Image>().sprite = yellowSprite;
    item3.GetComponent<Image>().sprite = yellowSprite;
        PlayerPrefs.SetInt("WhichParticle", 0);



    }

    public void OpenParticle2() {
    {
       
            particle.SetActive(false);
            particle1.SetActive(true);
            particle2.SetActive(false);
            particle3.SetActive(false);
            item.GetComponent<Image>().sprite = yellowSprite;
            item1.GetComponent<Image>().sprite = greenSprite;
            item2.GetComponent<Image>().sprite = yellowSprite;
            item3.GetComponent<Image>().sprite = yellowSprite;
            PlayerPrefs.SetInt("WhichParticle", 1);

        }
       
       

    }

    public void OpenParticle3() 
    {
            particle.SetActive(false);
            particle1.SetActive(false);
            particle2.SetActive(true);
            particle3.SetActive(false);
            item.GetComponent<Image>().sprite = yellowSprite;
            item1.GetComponent<Image>().sprite = yellowSprite;
            item2.GetComponent<Image>().sprite = greenSprite;
            item3.GetComponent<Image>().sprite = yellowSprite;
        PlayerPrefs.SetInt("WhichParticle", 2);


    }
    public void OpenParticle4()
    {
       
            particle.SetActive(false);
            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(true);
            item.GetComponent<Image>().sprite = yellowSprite;
            item1.GetComponent<Image>().sprite = yellowSprite;
            item2.GetComponent<Image>().sprite = yellowSprite;
            item3.GetComponent<Image>().sprite = greenSprite;
        PlayerPrefs.SetInt("WhichParticle", 3);



    }

    public void Lock1Open() 
    {
        int lock1Control = PlayerPrefs.GetInt("lock1");
        int money = PlayerPrefs.GetInt("Money");
        if(money >= 2000 && lock1Control == 0) 
        {
            lock1.SetActive(false);
            PlayerPrefs.SetInt("Money", money - 2000);
            OpenParticle2();
            uiManager.CoinText();
            PlayerPrefs.SetInt("lock1",1);
           



        }
    }
    public void Lock2Open()
    {
        int lock2Control = PlayerPrefs.GetInt("lock2");
        int money = PlayerPrefs.GetInt("Money");
       
        if (money >= 4000 && lock2Control == 0)
        {
            lock2.SetActive(false);
            PlayerPrefs.SetInt("Money", money - 4000);
            OpenParticle3();
            uiManager.CoinText();
            PlayerPrefs.SetInt("lock2", 1);
            
        }
    }

    public void Lock3Open()
    {
        int lock3Control = PlayerPrefs.GetInt("lock3");
        int money = PlayerPrefs.GetInt("Money");
        if (money >= 6000 && lock3Control == 0)
        {
            lock3.SetActive(false);
            PlayerPrefs.SetInt("Money", money - 6000);
            OpenParticle4();
            uiManager.CoinText();
            PlayerPrefs.SetInt("lock3", 1);
         

        }
    }






}
