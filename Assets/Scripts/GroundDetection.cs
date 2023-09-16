using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private PlayerController PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerExit(Collider collision)
    {
        if(!collision.isTrigger)
        PC.grounded = false;
    }
    void OnTriggerStay(Collider collision)
    {
        if (!collision.isTrigger)
            PC.grounded = true;
    }
}
