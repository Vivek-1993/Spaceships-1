using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootLeft : MonoBehaviour
{
    public GameObject LightGreen;
    public GameObject LightRed;
    private float timeStamp;
    private float buttonCooldown = 0.5f; // In Seconds
    public AudioSource audioClick;
    public AudioSource audioWaiting;
    public AudioSource audioShoot;

    public Transform muzzle;
    public GameObject shotPrefab;

    void OnCollisionEnter(Collision col)
    {
        if (timeStamp <= Time.time)
        {
            Debug.Log("Collision Left");
            audioClick.Play();
            audioShoot.Play();
            GameObject laser = GameObject.Instantiate(shotPrefab, muzzle.position, muzzle.rotation) as GameObject;
            GameObject.Destroy(laser, 0.5f);

            timeStamp = Time.time + buttonCooldown;
        }
        else if (!audioWaiting.isPlaying && !audioClick.isPlaying)
        {
            audioWaiting.Play();
        }
    }

    void Update()
    {
        if (timeStamp <= Time.time)
        {
            LightGreen.SetActive(true);
            LightRed.SetActive(false);
        }
        else
        {
            LightGreen.SetActive(false);
            LightRed.SetActive(true);
        }
    }
}



//public class Shoot : MonoBehaviour
//{
//    public GameObject buttonBase;
//    public bool buttonCollision = false;
//    float releasedPosition = 12.0f;
//    float pressedPosition = 12.06f;
//    float x;
//    float y;

//    void OnCollisionEnter(Collision col)
//    {
//        //Debug.Log("Collision: " + this.gameObject.name);
//        //Destroy(this.gameObject);

//        //if (col.gameObject == buttonBase)
//        //{
//        Debug.Log("Collision Enter");
//        buttonCollision = true;
//        //}
//    }

//    //void OnCollisionStay(Collision col)
//    //{
//    //    Debug.Log("Collision Stay");
//    //    buttonCollision = true;
//    //}

//    void OnCollisionExit(Collision col)
//    {
//        Debug.Log("Collision Exit");
//        buttonCollision = false;
//    }

//    void Start()
//    {
//        x = this.gameObject.transform.localPosition.x;
//        y = this.gameObject.transform.localPosition.y;
//    } 

//    void Update()
//    {
//        Debug.Log("Collision State : " + buttonCollision);
//        if (this.gameObject.transform.localPosition.z >= pressedPosition && buttonCollision == true)
//        {
//            Debug.Log("Collision: " + this.gameObject.name + " pressed");

//        }
//        else if (buttonCollision == false)
//        {
//            Debug.Log("Collision: " + this.gameObject.name + " released");
//            //this.gameObject.transform.localPosition = new Vector3(x, y, releasedPosition);
//            this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * 0.05f;

//        }


//        if (this.gameObject.transform.localPosition.z > pressedPosition)
//        {
//            this.gameObject.transform.localPosition = new Vector3(x, y, pressedPosition);
//        }
//        else if (this.gameObject.transform.localPosition.z < releasedPosition)
//        {
//            this.gameObject.transform.localPosition = new Vector3(x, y, releasedPosition);
//        }
//    }
//}