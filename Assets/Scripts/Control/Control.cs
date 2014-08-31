using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {


    [SerializeField]
    GameObject hud;
    [SerializeField]
    GameObject arrows;
    [SerializeField]
    GameObject dir;
    public bool willUseAccelerometer;



    public void ChooseControl(bool willUse)
    {
        
        willUseAccelerometer = willUse;
        hud.SetActive(true);
        if(willUse)
        {
            arrows.SetActive(false);
            Debug.Log(arrows.activeSelf);
        }

        
        Time.timeScale = 1;
        dir.SetActive(false);
    }
}
