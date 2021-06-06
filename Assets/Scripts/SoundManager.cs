using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource Musica;
    public AudioSource SomTiro;
    public AudioSource SomLaser;
    public AudioSource SomMorte;
    public static SoundManager instance = null;
    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    // Use this for initialization
    void Awake () {
        if(instance == null)
        {
            instance = this;
        }else if(instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	public void PlaySingle (AudioClip clip)

    {
        Musica.clip = clip;
        Musica.Play();
	}

    public void PlayTiro (string arma)
    {
        if(arma == "Tiro")
        {
            SomTiro.Play();
        }else if(arma == "Laser")
        {
            SomLaser.Play();
        }else if (arma == "Morte")
        {
            SomMorte.Play();
        }
    }
}
