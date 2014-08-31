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
    [SerializeField]
    private GameObject thisInterface;
    [SerializeField]
    private GameObject interfaceRanking;

    void OnEnable()
    {
        Invoke("ShowRanking", 30f);
    }

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
        CancelInvoke();
        gameInterface.SetActive( false );
        game.SetActive( true );
    }

    private void ClearScore()
    {
        Debug.Log("Clear");
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(0);
    }

    private void ShowRanking()
    {
        thisInterface.SetActive(false);
        interfaceRanking.SetActive(true);
    }
}
