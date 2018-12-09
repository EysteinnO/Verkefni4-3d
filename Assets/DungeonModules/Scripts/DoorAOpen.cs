using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAOpen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    AudioSource audiosource;
    public AudioClip DoorOpens;
    public bool enter;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true; 
            GetComponent<Animator>().SetTrigger("DoorATrigger");
            audiosource = gameObject.AddComponent<AudioSource>();       
            audiosource.volume = 5;
            audiosource.clip = DoorOpens;            
            audiosource.PlayOneShot(DoorOpens);
        }
        Debug.Log("Entered");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
        Debug.Log("Exited");
    }
}