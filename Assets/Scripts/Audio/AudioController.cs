using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    [RequireComponent( typeof( AudioSource ) )]
public class AudioController : MonoBehaviour {


    [SerializeField]
    private List<AudioClip>musicList = new List<AudioClip>( );

	void Start () 
    {
        int index = Random.Range( 0, 3 );
        audio.clip = musicList[index];
        audio.Play( );
        audio.loop = true;
	}
	
}
                                        