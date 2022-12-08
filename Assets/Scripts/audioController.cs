using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    //GESTION SONIDO
    public AudioClip snd_ganar;
    public AudioClip snd_perder;

    private AudioSource audsou;

    void Start() {
        audsou = GetComponent<AudioSource>();
    }

    //SINGLETON
    public static audioController instance = null; 
    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dead(){
        audsou.PlayOneShot(snd_perder);
    }

    public void win(){
        audsou.PlayOneShot(snd_ganar);
    }
}
