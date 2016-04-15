using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    
    public static SoundManager Instace { get; private set;}

    [SerializeField]private AudioClip   gameOverSnd;
    [SerializeField]private AudioClip   coinSnd;
    [SerializeField]private AudioClip   jumpSnd;
    [SerializeField]private AudioClip   clickSnd;
    [SerializeField]private float       musicDelaySec;

    private AudioSource source;
	
    void Awake()
    {
        Instace = this;
        source = GetComponent<AudioSource>();
        Invoke("PlayBackGround",musicDelaySec);
    }

    void PlayBackGround()
    {
        //Map01 Background
        source.Play();
    }

    void PlayEffectSound()
    {
        
    }

    public void PlayJumpSound()
    {
        source.PlayOneShot(jumpSnd);
    }
    public void PlayClickSound()
    {
        source.PlayOneShot(clickSnd);
    }
    public void PlayGame_Over()
    {       
        source.Stop();
        //GameOver
        source.PlayOneShot(gameOverSnd);
        
    }

}
