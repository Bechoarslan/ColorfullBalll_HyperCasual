using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 

    [SerializeField] UIManager uiManager;
    [SerializeField] GameAd gameAd;
    public void Start() 
    {
       
        CoinCalculater(0);
        
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine")) 
        {
            
            Debug.Log("Oyun bitti");
            CoinCalculater(100);
            uiManager.GetComponent<UIManager>().CoinText();
            uiManager.StartCoroutine(uiManager.FinishScreenOpen());
            PlayerPrefs.SetInt("LevelIndex",PlayerPrefs.GetInt("LevelIndex") + 1);
            if(PlayerPrefs.GetInt("NoAds") == 0) 
            {
                gameAd.LoadInterstitialAd();

            }
          
            gameAd.LoadRewardedAd();
            
        }
        
    }

    private void CoinCalculater(int money) 
    {
        if(PlayerPrefs.HasKey("Money")) 
        {
            int oldMoney = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", oldMoney + money);
        }
        else 
        {
            PlayerPrefs.SetInt("Money",0);
        }
    }
}
