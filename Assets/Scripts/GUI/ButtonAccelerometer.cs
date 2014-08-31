using UnityEngine;
using System.Collections;

public class ButtonAccelerometer : MonoBehaviour
{

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private bool messageParams;
    [SerializeField]
    private string messageUpAsButtonMessage;

    void OnMouseUpAsButton( )
    {
        Debug.Log(messageParams);
        target.SendMessage( messageUpAsButtonMessage, messageParams, SendMessageOptions.DontRequireReceiver );
       
    }
}
