using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question : MonoBehaviour
{
    [SerializeField]
    private List<GameObject>questionsMarks = new List<GameObject>( );
    [SerializeField]
    private GameObject gui;
    private int selectedAnswer;
    public int rightAnswer;

    void SelectAnswer( )
    {
        for ( int i = 0; i < questionsMarks.Count; i++ )
        {
            questionsMarks[ i ].renderer.enabled = false;
        }
    }

    void ConfirmAnswer()
    {
        for ( int i = 0; i < questionsMarks.Count; i++ )
        {
            if ( questionsMarks[ i ].renderer.enabled )
            {
                selectedAnswer = i;

                if ( selectedAnswer == rightAnswer )
                {
                    this.gameObject.SetActive( false );
                    Time.timeScale = 1;
                    gui.SetActive( true );
                    Debug.Log( "certa" );
                }
                else
                {
                    this.gameObject.SetActive( false );
                    Time.timeScale = 1;
                    GameManager.Instance.GrowTime( );
                    gui.SetActive( true );
                    Debug.Log( "errada" );
                }
            }
        }
    }

}
