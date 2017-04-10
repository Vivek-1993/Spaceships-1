using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRight : MonoBehaviour
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
            Debug.Log("Collision Right");
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


    //// Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
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
