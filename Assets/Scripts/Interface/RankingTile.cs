using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RankingTile : MonoBehaviour {

    [SerializeField]
    private TextMesh name;
    [SerializeField]
    private TextMesh time;

    public void Setup(string name, float time)
    {
        this.name.text = name;
        TimeSpan span   = new TimeSpan( 0, 0, 0, 0, Convert.ToInt32(time) );
        this.time.text = span.Minutes + ":" + span.Seconds + ":" + span.Milliseconds;
    }
}
