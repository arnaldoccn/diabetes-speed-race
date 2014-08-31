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
	[SerializeField]
	Car car;


    public void ChooseControl(bool willUse)
    {
        
        willUseAccelerometer = willUse;
        hud.SetActive(true);
        if(willUse)
        {
			car.accelerometerControl = true;
            arrows.SetActive(false);
            Debug.Log(arrows.activeSelf);
        }

        
        Time.timeScale = 1;
        dir.SetActive(false);
    }
}
