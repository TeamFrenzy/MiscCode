using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public GameObject limitLogo2;
    public GameObject introImage;
    public GameObject whiteCover;
    public GameObject bgMusic;
    public GameObject airSound;
    public GameObject planeSound;
    Color startColor;
    public float timer;
    public float colorTimer;
    public float positionTimer;
    public float musicStart;
    public float airStart;
    public float planeStart;
    float yStartPosition;
    // Start is called before the first frame update
    void Awake()
    {
        yStartPosition = 0.77f;
        timer = 0f;
        colorTimer = 0f;
        positionTimer = 0f;
        startColor = whiteCover.GetComponent<Renderer>().material.color;
        startColor.a = 0f;
        whiteCover.GetComponent<Renderer>().material.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if(timer>=3f && positionTimer<=0.5f)
        {
            positionTimer = positionTimer + (Time.deltaTime/20f);
            limitLogo2.transform.position = new Vector3(-0.02f, yStartPosition + positionTimer, -9.35f);
        }

        if(timer>=5f && timer<9f && colorTimer<1f)
        {
            colorTimer = colorTimer + (Time.deltaTime/2f);
            startColor.a = colorTimer;
            whiteCover.GetComponent<Renderer>().material.color = startColor;
        }

        if(timer>=9f && colorTimer>=-0.5f)
        {
            limitLogo2.SetActive(false);
            introImage.SetActive(false);
            colorTimer = colorTimer - (Time.deltaTime / 4f);
            startColor.a = colorTimer;
            whiteCover.GetComponent<Renderer>().material.color = startColor;
            if(colorTimer<=0f)
            {
                whiteCover.SetActive(false);
            }
        }

        if(timer>=musicStart)
        {
            bgMusic.SetActive(true);
        }

        if (timer >= planeStart)
        {
            planeSound.SetActive(true);
        }

        if (timer >= airStart)
        {
            airSound.SetActive(true);
        }


    }
}
