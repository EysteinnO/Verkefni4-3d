using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour {

    AudioSource audiosource;
    public AudioClip portalsound;

    // Use this for initialization
    void Start()
    {

    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audiosource = gameObject.AddComponent<AudioSource>();
            audiosource.volume = 5;
            audiosource.clip = portalsound;
            audiosource.PlayOneShot(portalsound);
            StartCoroutine(waiter());
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1b");
        }
        Debug.Log("Changed level");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
