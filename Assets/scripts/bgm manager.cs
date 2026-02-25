using UnityEngine;

public class bgmmanager : MonoBehaviour
{
    public AudioClip gameMusic;

    private AudioSource _audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Start()
    {
       StartBGM();
        //_audioSource.Play();
    }
    void StartBGM()
    {
        _audioSource.loop = true;
        _audioSource.clip = gameMusic;
        _audioSource.Play();


       // _audioSource.Pause();
       // _audioSource.Stop();
    }
}

