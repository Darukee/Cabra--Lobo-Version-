using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource audioSource;
    [Header("AudioClip")]
    [SerializeField] AudioClip mainMenu;

    void Start()
    {
        audioSource.clip = mainMenu;
        audioSource.Play();

    }
    void Update()
    {
        
    }
}
