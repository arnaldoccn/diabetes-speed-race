using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InterfacePostGame : MonoBehaviour {

    [SerializeField]
    private GameObject minibula;
    [SerializeField]
    private GameObject ranking;
    [SerializeField]
    private List<GameObject> rankingTiles = new List<GameObject>( );
    private List<KeyValuePair<string, float>> rankingShowList;

    void Start()
    {
        Time.timeScale = 1;
        Invoke( "ShowRanking", 3f );
    }

    void ShowRanking()
    {
        minibula.SetActive( false );
        ranking.SetActive( true );
        rankingShowList = PersistentData.Instance.rankingList;
        Debug.Log( rankingTiles.Count );
        for ( int i = 0; i < rankingTiles.Count; i++ )
        {
            if ( rankingShowList.Count > i )
            {
                 rankingTiles[ i ].SetActive( true );
                  var item = rankingShowList.ElementAt( i );
                  Debug.Log( item.Key + " " + item.Value );
                 rankingTiles[ i ].GetComponent<RankingTile>( ).Setup( item.Key, item.Value );  
            } 
        }
        Invoke( "ReloadScene", 8f );
    }

    void ReloadScene()
    {
        Application.LoadLevel( 0 );
    }
}
