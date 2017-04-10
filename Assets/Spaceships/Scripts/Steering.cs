using System.Collections;
using UnityEngine;

public class Steering : MonoBehaviour
{ 
    public GameObject steeringWheelObject;
    public GameObject spaceshipRigObject;
    float steeringWheelStartAngle;
    float steeringWheelFinalAngle;
    float steeringWheelAngleDifference;

    float posX;
    float posY;
    float posZ;


    // Use this for initialization
    void Start()
    {
        posX = steeringWheelObject.transform.localPosition.x;
        posY = steeringWheelObject.transform.localPosition.y;
        posZ = steeringWheelObject.transform.localPosition.z;
    }

    // Saves values of angles of steering wheel one second apart, used to check direction of movement in Update()
    private IEnumerator CheckRotation()
    {
        steeringWheelStartAngle = steeringWheelObject.transform.localRotation.eulerAngles.z;
        //Debug.Log("Steering Wheel Start Angle = " + steeringWheelStartAngle);
        yield return new WaitForSeconds(1.0f);
        steeringWheelFinalAngle = steeringWheelObject.transform.localRotation.eulerAngles.z;
        //Debug.Log("Steering Wheel Final Angle = " + steeringWheelFinalAngle);
    }

    // Update is called once per frame
    void Update ()
    {
        StartCoroutine(CheckRotation());
        steeringWheelAngleDifference = steeringWheelFinalAngle - steeringWheelStartAngle;

        // When angle goes past 360 and ends up back at 0, or goes below 0 and ends up at 359 etc,
        // to prevent moving in wrong direction that particular angle change is ignored
        // by only accepting differences in angle change that are greater than -180 and less than 180.
        if (steeringWheelAngleDifference < 180 && steeringWheelAngleDifference > -180)
        {
            //Debug.Log(" Steering Wheel Angle Difference: " + steeringWheelAngleDifference);
            if (steeringWheelFinalAngle > steeringWheelStartAngle)
            {
                //Debug.Log("Move Right");
                spaceshipRigObject.transform.Rotate(Vector3.up, 10 * steeringWheelAngleDifference * Time.deltaTime);
            }
            else if (steeringWheelFinalAngle < steeringWheelStartAngle)
            {
                //Debug.Log("Move Left");
                spaceshipRigObject.transform.Rotate(Vector3.up, 10 * steeringWheelAngleDifference * Time.deltaTime);
            }
        }
    }

    //To keep the rotation frozen to only allow z axis to rotate on the steering wheel object.
    protected void LateUpdate()
    {
        steeringWheelObject.transform.localEulerAngles = new Vector3(0, 0, steeringWheelObject.transform.localEulerAngles.z);
        steeringWheelObject.transform.localPosition = new Vector3(posX, posY, posZ);
    }

}

