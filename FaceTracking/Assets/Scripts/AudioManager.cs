using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource[] ass;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ass = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayArrowReleaseSound()
    {
        ass[0].Play();
    }
    public void PlayArrowImpactSound()
    {
        ass[1].Play();
    }
}
