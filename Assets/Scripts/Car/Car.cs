using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    [SerializeField]
    private Transform[] wheels = new Transform[ 4 ];
    [SerializeField]
    private double enginePower = 90.0f;
    [SerializeField]
    private double maxSteer = 25.0f;
    [SerializeField]
    private GameObject GUI;
    [SerializeField]
    private GameObject firstSpeedControllerPoint;
    [SerializeField]
    private GameObject glass;
	public bool gameIsOver;

    private GameObject lastSpeedControllerPoint;
    private double power = 0.0f;
    private double brake = 0.0f;
    private double steer = 0.0f;
    private double actualToque = -300;

    private int count = 0;

    public GameObject actualReturnPoint;
    public Vector3 actualReturnPointPosition;
    public Vector3 actualReturnPointRotation;
    public float actualReturnPointSpeed;
    public bool accelerometerControl;

	void Start () 
    {
       
        lastSpeedControllerPoint = firstSpeedControllerPoint;
        this.rigidbody.centerOfMass = new Vector3(0,-0.5f,0.3f);
        GUI.SetActive( false );
        GUI.SetActive( true );
	}

    void Update( )
    {
        if ( GameManager.Instance )
        {
            if ( !GameManager.Instance.gameOverFlag )
            {
                power = Input.GetAxis( "Vertical" ) * enginePower * Time.deltaTime * 250.0;
                steer = Input.GetAxis( "Horizontal" ) * maxSteer;
                brake = Input.GetKey( "space" ) ? rigidbody.mass * 0.1 : 0.0;

                GetCollider( 0 ).brakeTorque = 0;
                GetCollider( 1 ).brakeTorque = 0;
                GetCollider( 2 ).brakeTorque = 0;
                GetCollider( 3 ).brakeTorque = 0;
                GetCollider( 2 ).motorTorque = ( float )actualToque;
                GetCollider( 3 ).motorTorque = ( float )actualToque;
            }
        }

        if ( this.transform.rotation.eulerAngles.x >= 280 || this.transform.rotation.eulerAngles.x <= 260)
        {
            count++;
            if(count >=90 && !gameIsOver)
            {
                ReturnCar( );
            }
        }
        else
        {
            count = 0;
        }

		if (accelerometerControl)
		{
			steer =  11.5f * Input.acceleration.x;
			GetCollider( 0 ).steerAngle = ( float )steer;
			GetCollider( 1 ).steerAngle = ( float )steer;
		}   
    }

    private WheelCollider GetCollider(int n)
    {
        return (WheelCollider) wheels[n].gameObject.GetComponent("WheelCollider");
    }

    public void ChangueTorque(int newTorque, GameObject lastspeedControllerPoint)
    {
        actualToque = newTorque;
        this.lastSpeedControllerPoint = lastspeedControllerPoint;
    }

    public void TurnLeft()
    {
        steer = -10f;
        GetCollider( 0 ).steerAngle = ( float )steer;
        GetCollider( 1 ).steerAngle = ( float )steer;
    }
    public void TurnRight( )
    {
        steer = 10f;
        GetCollider( 0 ).steerAngle = ( float )steer;
        GetCollider( 1 ).steerAngle = ( float )steer;
    }

    public void StopTurning()
    {
        steer = 0;
        GetCollider( 0 ).steerAngle = ( float )steer;
        GetCollider( 1 ).steerAngle = ( float )steer;
    }

    private void ReturnCar( )
    {

        StopTurning( );
        this.transform.localPosition = actualReturnPointPosition;
        this.transform.localRotation = Quaternion.Euler( actualReturnPointRotation );
        actualToque = actualReturnPointSpeed;
    }
    private void RestarGame()
    {
        Application.LoadLevel( 0 );
    }
}