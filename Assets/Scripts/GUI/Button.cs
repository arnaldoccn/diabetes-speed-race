using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private string messageUp;
    [SerializeField]
    private string messageDrag;

    void OnMouseDrag( )
    {
        target.SendMessage( messageDrag, SendMessageOptions.DontRequireReceiver );
    }

    void OnMouseUp( )
    {
        target.SendMessage( messageUp, SendMessageOptions.DontRequireReceiver );
    }
}
