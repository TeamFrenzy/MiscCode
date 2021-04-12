using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject limitLogo;
    public float colorTimer;

    public Vector2 range = new Vector2(5f, 3f);
    public Transform mTrans;
    Quaternion mStart;
    Vector2 mRot = Vector2.zero;

    // Start is called before the first frame update
    void Awake()
    {
        mStart = mTrans.localRotation;
        colorTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.H))
        {
            if(colorTimer>0f)
            {
                colorTimer = colorTimer - (Time.deltaTime / 1.5f);
                canvasGroup.alpha = colorTimer;
                Color startColor = limitLogo.GetComponent<Renderer>().material.color;
                startColor.a = colorTimer;
                limitLogo.GetComponent<Renderer>().material.color = startColor;
            }

            Vector3 pos = Input.mousePosition;

            float halfWidth = Screen.width * 0.5f;
            float halfHeight = Screen.height * 0.5f;
            float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth, -1f, 1f);
            float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight, -1f, 1f);
            mRot = Vector2.Lerp(mRot, new Vector2(x, y), Time.deltaTime * 5f);

            mTrans.localRotation = mStart * Quaternion.Euler(-mRot.y * range.y, mRot.x * range.x, 0f);
        }
        else
        {
            if(colorTimer<1f)
            {
                colorTimer = colorTimer + (Time.deltaTime / 1.5f);
                canvasGroup.alpha = colorTimer;
                Color startColor = limitLogo.GetComponent<Renderer>().material.color;
                startColor.a = colorTimer;
                limitLogo.GetComponent<Renderer>().material.color = startColor;
            }
        }
    }
}
