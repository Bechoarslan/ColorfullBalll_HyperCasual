using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;

   
    public void Start() 
    {
        if(PlayerPrefs.HasKey("LevelIndex") == false) 
        {
            PlayerPrefs.SetInt("LevelIndex",1);
        }
        StartCoroutine(LoadingText());
        LoadScene();




    }


    public void LoadScene() 
    {
        int level = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadSceneAsync(level);
    }







    public IEnumerator LoadingText() 
    {
        while(true) {
        loadingText.text = "Loading".ToString();
        yield return new WaitForSeconds(0.5f);
        loadingText.text = "Loading.".ToString();
        yield return new WaitForSeconds(0.5f);
        loadingText.text = "Loading..".ToString();
        yield return new WaitForSeconds(0.5f);
        loadingText.text = "Loading..".ToString();
        yield return new WaitForSeconds(0.5f);
        }
    }
}
