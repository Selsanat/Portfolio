using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPresentationJeuFixPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        gameObject.GetComponent<CharacterJoint>().connectedBody = player.GetComponent<Rigidbody>();
    }

}
