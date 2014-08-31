using UnityEngine;
using System.Collections;

public class RankingButton : MonoBehaviour {
	public GameObject interfaceGame;
	public GameObject interfaceRanking;

	void OnMouseUpAsButton( )
	{
        interfaceGame.SetActive(false);
        interfaceRanking.SetActive(true);
	}
}
