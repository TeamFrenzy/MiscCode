using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public Camera cam;
    public GameObject settings;
    public GameObject credits;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToSettings(Camera cam)
    {
        cam.transform.LookAt(settings.transform);
    }

    public void GoToCredits(Camera cam)
    {
        cam.transform.LookAt(credits.transform);
    }

    public void GoToMainMenu(Camera cam)
    {
        cam.transform.LookAt(mainMenu.transform);
    }
}
