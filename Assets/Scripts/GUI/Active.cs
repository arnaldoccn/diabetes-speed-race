using UnityEngine;
using System.Collections;

public class Active : MonoBehaviour
{
	void Start () {

        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
	}

}
