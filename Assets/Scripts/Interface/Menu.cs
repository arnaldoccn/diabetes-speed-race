using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    [SerializeField]
    private List<GameObject>screenList = new List<GameObject>( );
    [SerializeField]
    private GameObject gameInterface;
    [SerializeField]
    private GameObject game;

	void GoToTheSecondScreen () 
    {
        PersistentData.Instance.SaveNameAndCRM( );
        for ( int i = 0; i < screenList.Count; i++ )
        {
            if(screenList[i].activeSelf)
            {
                screenList[ i ].SetActive( false );
            }
            else
            {
                screenList[ i ].SetActive( true );
            }
        }
	}

    void InitGame()
    {
        gameInterface.SetActive( false );
        game.SetActive( true );
    }
}
