using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
   [SerializeField] private Image image;
   [SerializeField] private Animator layoutAnim;
   [SerializeField] private GameObject settingsOpen;
   [SerializeField] private GameObject settingsClose;
   [SerializeField] private GameObject soundOn;
   [SerializeField] private GameObject soundOff;
   [SerializeField] private GameObject vibrationOn;
   [SerializeField] private GameObject vibrationOff;
   [SerializeField] private GameObject informationButton;
   [SerializeField] private GameObject informationUI;
   [SerializeField] private GameObject[] UIelements;
   [SerializeField] private GameObject restart;
   [SerializeField] private GameObject layerGroup;
   [SerializeField] private TextMeshProUGUI coinText;
   [SerializeField] private GameObject finishScreen;
    [SerializeField] private GameObject coinButton;
    [SerializeField] private GameObject completeImage;
    [SerializeField] private GameObject adImage;
    [SerializeField] private GameObject skipText;
    [SerializeField] private GameObject spark;
    [SerializeField] private Transform player;
    [SerializeField] private Transform finishLineVector;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject rewardCoin;
    [SerializeField] private TextMeshProUGUI achievedCoinText;
    [SerializeField] private GameObject bb;
    [SerializeField] private GameObject aa;
    [SerializeField] private GameObject cc;

    [SerializeField] private Sound soundManager;




    private int effectControl = 0;

private void Start() 
{   
    if(PlayerPrefs.HasKey("Sound") == false) 
  {
   PlayerPrefs.SetInt("Sound",1);
  }
  if(PlayerPrefs.HasKey("Vibration") == false) 
  {
   PlayerPrefs.SetInt("Vibration",1);
  }
        
        CoinText();

        if(PlayerPrefs.GetInt("NoAds") == 1) 
        {
            UIelements[2].SetActive(false);
        }


    }

void Update() 
{
    DistanceCalculater();
        
    }

private void DistanceCalculater() 
{
    if(slider.value == 0) return;
 
 int afterDistance =(int)Vector3.Distance(player.position,finishLineVector.position);
 
 
 slider.value = afterDistance;
 

 

 
}
public void NoAds() 
{
    UIelements[2].SetActive(false);
    
}
public IEnumerator FinishScreenOpen() 
{
    yield return new WaitForSeconds(1);
    Variables.firstTouch = 0;
    Variables.cameraTouch = 0;
    soundManager.FinishSound();
    
    finishScreen.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    completeImage.SetActive(true);
    completeImage.GetComponent<Animator>().SetTrigger("CompletedTrigger");
    yield return new WaitForSeconds(0.5f);
    coinButton.SetActive(true);
    bb.SetActive(true);
    coinButton.GetComponent<Animator>().SetTrigger("CoinTrigger");
    
    spark.SetActive(true);
    spark.GetComponent<Animator>().SetTrigger("SparkTrigger");
    yield return new WaitForSeconds(0.5f);
    adImage.SetActive(true);
    aa.SetActive(true);
    cc.SetActive(true);
    adImage.GetComponent<Animator>().SetTrigger("RewardTrigger");
    yield return new WaitForSeconds(1.5f);
    skipText.SetActive(true);
    skipText.GetComponent<Animator>().SetTrigger("SkipTrigger");
}


public bool RestartButton(bool isHit) 
{
    if(isHit) 
    {
      
      Variables.firstTouch = 0;
       return true;
    }
    return false;
    
   
}

public IEnumerator AfterRewardButton() 
{
    rewardCoin.SetActive(true);
    achievedCoinText.gameObject.SetActive(true);
        skipText.SetActive(false);
        adImage.SetActive(false);
        for (int i = 0; i < 401; i += 4)
        {
            achievedCoinText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);

        }

   
    yield return new WaitForSeconds(1f);
    nextLevel.SetActive(true);
   
    
}

public void StartNextSceneUI() 
{
    StartCoroutine(AfterRewardButton());
}


public void CoinText() 
{
    coinText.text = PlayerPrefs.GetInt("Money").ToString();

}

public IEnumerator OpenRestartScene() 
{
    Time.timeScale = 0.4f;
    yield return new WaitForSeconds(1);
    restart.SetActive(true);
    

}

public void RestartCurrentScene() 
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
}

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }


    public void FirstTouch() 
    {
        foreach(GameObject elements in UIelements ) 
        {
            elements.SetActive(false);
        }
        settingsOpen.SetActive(false);
        settingsClose.SetActive(false);
        layerGroup.SetActive(false);
        
       
        
    }
 public void OpenSettings() 
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        layoutAnim.SetTrigger("SlideIn");
       

        if(PlayerPrefs.GetInt("Sound") == 1) 
        {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
            AudioListener.volume = 1;
        }
        else if(PlayerPrefs.GetInt("Sound") == 2)
        {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioListener.volume = 0;
        }

        if(PlayerPrefs.GetInt("Vibration") == 1) 
        {
        vibrationOff.SetActive(false);
        vibrationOn.SetActive(true);

        }
        else if(PlayerPrefs.GetInt("Vibration") == 2) 
        {
            vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        }
    }

    public void CloseSettings() 
    { settingsClose.SetActive(false);
      settingsOpen.SetActive(true);
      layoutAnim.SetTrigger("SlideOut");
      

    }
    public void OpenSoundSettings() 
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        PlayerPrefs.SetInt("Sound",2);

    }
    public void CloseSoundSettings() 
    {
        soundOff.SetActive(false);
        soundOn.SetActive(true);
        PlayerPrefs.SetInt("Sound",1);

    }

    public void OpenVibrationSettings() 
    {
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("Vibration",2);
        
        
    }

    public void CloseVibrationSettings() 
    {
        vibrationOff.SetActive(false);
        vibrationOn.SetActive(true);
        PlayerPrefs.SetInt("Vibration",1);
    }

    public void Privacy_Policy() 
    {
        Application.OpenURL("https://github.com/Bechoarslan");
    }

    public void TermOfUse() 
    {
        Application.OpenURL("https://github.com/Bechoarslan");
    }

   
    public IEnumerator WhiteEffect( ) 
    {
        image.gameObject.SetActive(true);
        while(effectControl == 0) 
        {  yield return new WaitForSeconds(0.001f);
            image.color += new Color(0,0,0,0.1f);

            if(image.color == new Color(image.color.r,image.color.g,image.color.b,1)) 
            {
                effectControl = 1;

            }
            
        }
        while(effectControl == 1) 
        {
            yield return new WaitForSeconds(0.001f);
            image.color -= new Color(0,0,0,0.1f);

            if(image.color == new Color(image.color.r,image.color.g,image.color.b,0)) 
            {
                effectControl = 2;

            }

        }

        

    }

    
    public void GetWhiteEffect() 
    {
        StartCoroutine(WhiteEffect());

    }
}
