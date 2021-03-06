﻿using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    [Tooltip("The 'animation' loop for movement to reach your desired movement units. The defaults move 1 Unity unit. Adjust this to suit your level design.")]
    public float fMovementIncrement = 0.05f;
    [Tooltip("The 'animation' loop for movement to reach your desired movement units. The defaults move 1 Unity unit. Adjust this to suit your level design.")]
    public float iMovementInterval = 20;
    [Tooltip("Locked Y position of the camera, adjust to suit your level design.")]
    public float fYLockPosition = 0f;
    [Tooltip("Public only for debugging, these values are overridden at runtime.")]
    public bool bMoving = false;
    [Tooltip("Public only for debugging, these values are overridden at runtime.")]
    public bool bRotating = false;
    [Tooltip("fRotateIncrement * iRotateInterval must equal 90 for full grid movement. For faster rotating, lower the interval and raise the increment.")]
    public float fRotateIncrement = 4.5f;
    [Tooltip("fRotateIncrement * iRotateInterval must equal 90 for full grid movement. For faster rotating, lower the interval and raise the increment.")]
    public int iRotateInterval = 20;
    [Tooltip("The WaitForSeconds value returned for each return yeild of the Coroutines.")]
    public float fWaitForSecondsInterval = 0.01f;

    public enum Compass { N, S, E, W }
    Compass currentCompass = Compass.N;

    


    void Start()
    {
        bMoving = false;
        bRotating = false;


    }   

    public Text m_text;
    
    AudioSource audiosource;
    AudioSource audiosource2;
    public AudioClip walk;
    public AudioClip walk1;    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse check");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = hitInfo.point;
            }
        }    

        if (!bRotating && !bMoving)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), fYLockPosition, Mathf.Round(transform.position.z));
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!bRotating && !bMoving)
            {
                StartCoroutine(StepForward());
                //audio
                audiosource = gameObject.AddComponent<AudioSource>();
                audiosource.volume = 5;
                audiosource.clip = walk;
                audiosource.Play();
                
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!bRotating && !bMoving)
            {
                StartCoroutine(StepBackward());
                //audio
                audiosource = gameObject.AddComponent<AudioSource>();
                audiosource.volume = 5;
                audiosource.clip = walk;
                audiosource.Play();
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (!bRotating && !bMoving)
            {
                StartCoroutine(StepLeft());
                //audio
                audiosource = gameObject.AddComponent<AudioSource>();
                audiosource.volume = 5;
                audiosource.clip = walk;
                audiosource.Play();
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (!bRotating && !bMoving)
            {
                StartCoroutine(StepRight());
                //audio
                audiosource = gameObject.AddComponent<AudioSource>();
                audiosource.volume = 5;
                audiosource.clip = walk;
                audiosource.Play();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!bRotating && !bMoving)
            {
                StartCoroutine(RotateRight());
                //audio
                audiosource2 = gameObject.AddComponent<AudioSource>();
                audiosource2.volume = 5;
                audiosource2.clip = walk1;
                audiosource2.Play();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!bRotating && !bMoving)
            {
                StartCoroutine(RotateLeft());
                //audio
                audiosource = gameObject.AddComponent<AudioSource>();
                audiosource.volume = 5;
                audiosource.clip = walk1;
                audiosource.Play();
            }
        }

        
        if (currentCompass == Compass.N)
        {
            m_text.text = "North";
        }

        if (currentCompass == Compass.S)
        {
            m_text.text = "South";
        }

        if (currentCompass == Compass.W)
        {
            m_text.text = "West";
        }

        if (currentCompass == Compass.E)
        {
            m_text.text = "East";
        }



    }

    

    IEnumerator StepForward()
    {
        Vector3 newpos;
        if (currentCompass == Compass.N)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, .05f);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.S)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, -fMovementIncrement);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.E)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.W)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(-fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }


    }

    IEnumerator StepBackward()
    {
        Vector3 newpos;
        if (currentCompass == Compass.N)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, -.05f);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.S)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, fMovementIncrement);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.E)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(-fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.W)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }

    }

    IEnumerator StepLeft()
    {
        Vector3 newpos;
        if (currentCompass == Compass.N)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(-fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.S)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.E)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, fMovementIncrement);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.W)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, -fMovementIncrement);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }

        var wait = new WaitForSeconds(0.1f);


    }

    IEnumerator StepRight()
    {
        Vector3 newpos;
        if (currentCompass == Compass.N)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.S)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(-fMovementIncrement, 0, 0);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.E)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, -fMovementIncrement);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }
        if (currentCompass == Compass.W)
        {
            bMoving = true;
            for (int g = 0; g < iMovementInterval; g++)
            {
                newpos = new Vector3(0, 0, fMovementIncrement);
                transform.position += newpos;
                yield return new WaitForSeconds(fWaitForSecondsInterval);
            }
            yield return new WaitForSeconds(fWaitForSecondsInterval);
            bMoving = false;
        }

        var wait = new WaitForSeconds(0.1f);

    }

    IEnumerator RotateRight()
    {
        bRotating = true;

        for (int g = 0; g < iRotateInterval; g++)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), fYLockPosition, Mathf.Round(transform.position.z));
            transform.eulerAngles += new Vector3(0, fRotateIncrement, 0);
            yield return new WaitForSeconds(fWaitForSecondsInterval);
        }

        switch (currentCompass)
        {
            case (Compass.W):
                currentCompass = Compass.N;
                Debug.Log("Compass is now N");
                //text.text ="N";
                break;
            case (Compass.E):
                currentCompass = Compass.S;
                Debug.Log("Compass is now S");
                //text.text ="S";
                break;
            case (Compass.S):
                currentCompass = Compass.W;
                Debug.Log("Compass is now W");
                //text.text ="W";
                break;
            case (Compass.N):
                currentCompass = Compass.E;
                Debug.Log("Compass is now E");
                //text.text ="E";
                break;
        }
        yield return new WaitForSeconds(fWaitForSecondsInterval);
        bRotating = false;

        var wait = new WaitForSeconds(fWaitForSecondsInterval);


    }

    IEnumerator RotateLeft()
    {
        bRotating = true;
        for (int g = 0; g < iRotateInterval; g++)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), fYLockPosition, Mathf.Round(transform.position.z));
            transform.eulerAngles += new Vector3(0, -fRotateIncrement, 0);
            yield return new WaitForSeconds(fWaitForSecondsInterval);
        }

        switch (currentCompass)
        {
            case (Compass.W):
                currentCompass = Compass.S;
                break;
            case (Compass.E):
                currentCompass = Compass.N;
                break;
            case (Compass.S):
                currentCompass = Compass.E;
                break;
            case (Compass.N):
                currentCompass = Compass.W;
                break;
        }
        yield return new WaitForSeconds(fWaitForSecondsInterval);
        bRotating = false;

        var wait = new WaitForSeconds(fWaitForSecondsInterval);


             

    }
}