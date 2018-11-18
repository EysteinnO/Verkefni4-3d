using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ifpressed : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        animate = GetComponent<Animator>();
    } 

    Animator animate;
    
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            animate.Play("movepainting");
            Debug.Log("Entered painting");
        }
    }
    

    
	
	// Update is called once per frame
	void Update () {


		
	}
}
