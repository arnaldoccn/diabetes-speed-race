using UnityEngine;
using System.Collections;

public class QuestionsTriggers : MonoBehaviour {

    public GameObject questionToShow;
    [SerializeField]
    private GameObject gui;

    public void Setup(GameObject question)
    {
        questionToShow = question;
    }


    void OnTriggerEnter( Collider other )
    {
        if ( other.tag == "Car" )
        {
            gui.SetActive( false );
            Time.timeScale = 0;
            questionToShow.SetActive( true );
            this.gameObject.SetActive( false );
        }
    }
}
