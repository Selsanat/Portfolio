using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTourne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-8f, 60f, 0), 45.0f * Time.deltaTime);

    }
}
