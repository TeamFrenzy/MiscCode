using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    public GameObject continueMenu;
    Transform currentView;
    bool contActive;
    // Start is called before the first frame update
    void Start()
    {
        contActive = false;
        currentView = views[0];
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.eulerAngles.z, Time.deltaTime * transitionSpeed)
            );

        transform.eulerAngles = currentAngle;
    }

    public void GoToSettings()
    {
        currentView = views[1];
    }

    public void GoToCredits()
    {
        currentView = views[2];
    }

    public void GoToMainMenu()
    {
        currentView = views[0];
        if(contActive == true)
        {
            contActive = false;
            continueMenu.SetActive(false);
            //Color tempcolor = continueMenu.GetComponent<Renderer>().material.color;
            //tempcolor.a = Mathf.MoveTowards(1, 0, Time.deltaTime);
           // continueMenu.GetComponent<Renderer>().material.color = tempcolor;
        }
    }

    public void GoToContinue()
    {
        contActive = true;
        currentView = views[3];
        continueMenu.SetActive(true);
        //Color tempcolor = continueMenu.GetComponent<Renderer>().material.color;
        //tempcolor.a = Mathf.MoveTowards(0, 1, Time.deltaTime);
       // continueMenu.GetComponent<Renderer>().material.color = tempcolor;
    }
}
