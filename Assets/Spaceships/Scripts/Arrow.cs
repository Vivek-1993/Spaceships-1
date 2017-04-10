using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject star;

	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(star.transform);
    }
}
