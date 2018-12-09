using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crush : MonoBehaviour {

    public GameObject Player;
    public Text m_deathtext;
    private bool deathstate = false;
    Animator m_Animator;
    
   
    void Start () {
        m_Animator = GetComponent<Animator>();               
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        Application.LoadLevel(Application.loadedLevel);
    }

    

    // Update is called once per frame
    void Update () {
		
	}

    AudioSource audiosource;
    public AudioClip deathsound;
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            m_deathtext.text = "You died..";
            StartCoroutine(waiter());
            //StartCoroutine(Fade.DoFade());
            deathstate = true;
            audiosource = gameObject.AddComponent<AudioSource>();
            audiosource.volume = 5;
            audiosource.clip = deathsound;
            audiosource.Play();
        }        
    } 

    void OnTriggerEnter(Collider trigger)
    {

        if (trigger.gameObject.tag.Equals("Fall"))
        {
            //m_Animator.AnimatorCullingMode.AlwaysAnimate = 1;
            m_Animator.Play("fallanim");
            m_deathtext.text = "You died..";
            StartCoroutine(waiter());
            deathstate = true;
        }
                
    }



}
