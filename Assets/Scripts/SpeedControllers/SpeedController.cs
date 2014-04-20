using UnityEngine;
using System.Collections;

public class SpeedController : MonoBehaviour {

    [SerializeField]
    private int torque;

    void OnTriggerEnter( Collider other )
    {
       if(other.tag == "Car")
       {
           Debug.Log( "new torque: " + torque );
           other.GetComponent<Car>( ).ChangueTorque( torque, this.gameObject);
       }
    }
}
