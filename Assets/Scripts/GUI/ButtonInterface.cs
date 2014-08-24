using UnityEngine;
using System.Collections;

public class ButtonInterface : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private string messageParams;
    [SerializeField]
    private string messageUpAsButtonMessage;

    void OnMouseUpAsButton( )
    {
		Debug.Log("fdshjfsdjhf");
        target.SendMessage( messageUpAsButtonMessage, messageParams, SendMessageOptions.DontRequireReceiver );
        if ( this.renderer )
        {
            this.renderer.enabled = true;
        }
    }
}
