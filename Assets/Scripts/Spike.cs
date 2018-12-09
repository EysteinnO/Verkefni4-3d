using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    AudioSource audiosource2;
    public AudioClip spikesound;   

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update () {

        
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            audiosource2 = gameObject.AddComponent<AudioSource>();
            audiosource2.volume = 5;
            audiosource2.clip = spikesound;
            audiosource2.Play();
            //StartCoroutine(waiter());
            
        }
        Debug.Log("Collision");
    }





}
