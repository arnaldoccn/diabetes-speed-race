using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


    private float startTime;
    [SerializeField]
    private TextMesh time;
    [SerializeField]
    private GameOver gameOver;
    [SerializeField]
    private List<GameObject>questionsList = new List<GameObject>( );
    [SerializeField]
    private List<GameObject>questionsTriggers = new List<GameObject>( );
    private int miliseconds;
    public bool gameOverFlag = false;


    private bool alreadyCheck = false;
    private GameManager( ) { }

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }

    }
	void Start () 
    {
        instance = this;
        startTime = Time.time;
        RaffleQuestions( );
	}
	

	void Update ()
    {
        gameOverFlag = gameOver.gameIsOver;
        if ( !gameOverFlag )
        {
            miliseconds = Convert.ToInt32( ( Time.time - startTime ) * 1000 );
            TimeSpan span   = new TimeSpan( 0, 0, 0, 0, miliseconds );
            time.text = span.Minutes + ":" + span.Seconds + ":" + span.Milliseconds;
            gameOver.timeString = time.text;
        }
        else
        {
            if(!alreadyCheck)
            {
                PersistentData.Instance.time = miliseconds.ToString( );
                PersistentData.Instance.CheckRanking( );
                alreadyCheck = true;
            }
        }
	}

    public void RaffleQuestions( )
    {
        int[]numberToShuffler = {0,1,2,3,4,5};
        RandFuncs.Shuffle( numberToShuffler );
        for ( int i = 0; i < questionsTriggers.Count; i++ )
        {
            questionsTriggers[ i ].GetComponent<QuestionsTriggers>( ).Setup( questionsList[ numberToShuffler[ i ] ] );
        }
    }

    public void GrowTime()
    {
        startTime = startTime - 5;
    }
}
