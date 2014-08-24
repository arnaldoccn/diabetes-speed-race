using UnityEngine;
using System.Collections;

public class DesactiveGameObject : MonoBehaviour
{

    void OnEnable( )
    {
        Invoke( "Desactive", 2f );
    }

    void Desactive( )
    {
        this.gameObject.SetActive( false );
    }
}
