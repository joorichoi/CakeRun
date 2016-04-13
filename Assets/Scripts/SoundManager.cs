using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    
    public static SoundManager Instace { get; private set;}

    [SerializeField]private AudioClip gameOverSnd;
    [SerializeField]private AudioClip coinSnd;

    private AudioSource source;
	
    void Awake()
    {
        Instace = this;
        source = GetComponent<AudioSource>();
        Invoke("PlayBackGround",3.0f);
    }

    void PlayBackGround()
    {
        //Map01 Background
        source.Play();
    }

    void PlayEffectSound()
    {
        
    }

    public void PlayGame_Over()
    {       
        source.Stop();
        //GameOver
        source.PlayOneShot(gameOverSnd);
        
    }

}
