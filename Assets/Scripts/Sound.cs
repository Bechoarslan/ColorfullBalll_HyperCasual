using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource blastSound;
    [SerializeField] private AudioSource cashSound;
    [SerializeField] private AudioSource finishSound;
    [SerializeField] private AudioSource touchSound;


    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip blastClip;
    [SerializeField] private AudioClip cashClip;
    [SerializeField] private AudioClip finishClip;
    [SerializeField] private AudioClip touchClip;

    public void ButtonSound() 
    {
        buttonSound.PlayOneShot(buttonClip);
    }

    public void BlastSound() 
    {
        blastSound.PlayOneShot(blastClip,0.3f);
    }

    public void CashSound() 
    {
        cashSound.PlayOneShot(cashClip);
    }

    public void FinishSound() 
    {
        finishSound.PlayOneShot(finishClip);
    }

    public void TouchSound() 
    {
        
        touchSound.PlayOneShot(touchClip);
    }

}
