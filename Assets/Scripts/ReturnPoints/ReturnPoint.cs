using UnityEngine;
using System.Collections;

public class ReturnPoint : MonoBehaviour {

    [SerializeField]
    private Car car;
    [SerializeField]
    private Vector3 returnPosition;
    [SerializeField]
    private Vector3 returnRotation;
    [SerializeField]
    private float speed;

    void OnTriggerEnter( Collider other )
    {
        if ( other.tag == "Car" )
        {
            car.actualReturnPoint = this.gameObject;
            car.actualReturnPointPosition = returnPosition;
            car.actualReturnPointRotation = returnRotation;
            car.actualReturnPointSpeed = speed;
        }
    }
}
