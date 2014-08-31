using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    [SerializeField]
    private GameObject game;
    [SerializeField]
    private GameObject interfacePostGame;
    [SerializeField]
    private GameObject congratsScreen;
    [SerializeField]
    public TextMesh time;
    public string timeString;
    public bool gameIsOver = false;

    private int count = 0;

    void OnTriggerEnter( Collider other )
    {
        if ( other.tag == "Car" )
        {
            gameIsOver = true;
            
            congratsScreen.SetActive( true );
            
            time.text = timeString;
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        if(gameIsOver)
        {
            count++;
            if(count == 300)
            {
                DesactiveGame( );
            }
        }
    }

    private void DesactiveGame()
    {
        game.SetActive( false );
        interfacePostGame.SetActive( true );
    }

    
}
