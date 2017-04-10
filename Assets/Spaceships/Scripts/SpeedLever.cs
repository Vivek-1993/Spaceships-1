using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLever : MonoBehaviour
{
    public GameObject speedLeverObject;
    public GameObject spaceshipRigObject;
    public GameObject speedometerPointerObject;

    float speedLeverLowestPosition = 2.0f;
    float speedLeverHighestPostion = 2.5f;
    float movementSpeed;
    float speedometerAngle;

    float posX;
    float posZ;

    // Use this for initialization
    void Start ()
    {
        //initial positions of the lever at the start of the game
        //used to hold lever fixed in certain directions
        posX = speedLeverObject.transform.localPosition.x;
        posZ = speedLeverObject.transform.localPosition.z;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (speedLeverObject.transform.localPosition.y > speedLeverHighestPostion)
        {
            speedLeverObject.transform.localPosition = new Vector3(speedLeverObject.transform.localPosition.x, speedLeverHighestPostion, speedLeverObject.transform.localPosition.z);
        }
        else if (speedLeverObject.transform.localPosition.y < speedLeverLowestPosition)
        {
            speedLeverObject.transform.localPosition = new Vector3(speedLeverObject.transform.localPosition.x, speedLeverLowestPosition, speedLeverObject.transform.localPosition.z);
        }
        movementSpeed = speedLeverObject.transform.localPosition.y - speedLeverLowestPosition;
        //Debug.Log("Move Speed" + movementSpeed);
        spaceshipRigObject.transform.position += spaceshipRigObject.transform.forward * Time.deltaTime * movementSpeed * 10;

        //Speedometer
        // The default angle for 0 speed is 120 degrees and it moves in the negative direction as speed increases.
        speedometerAngle = 120 - (movementSpeed * 480);
        //Debug.Log("Speedometer Angle" + speedometerAngle);
        speedometerPointerObject.transform.localEulerAngles = new Vector3(0, 0, speedometerAngle);
    }

    void LateUpdate()
    {
        speedLeverObject.transform.localEulerAngles = new Vector3(0, 90, 0);
        speedLeverObject.transform.localPosition = new Vector3(posX, speedLeverObject.transform.localPosition.y, posZ);
    }
}
