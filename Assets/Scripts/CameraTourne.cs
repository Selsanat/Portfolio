using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTourne : MonoBehaviour
{
    public float decal = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] l = GameObject.FindGameObjectsWithTag("Player");
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            if (l.Length > 1)
            {
                foreach (GameObject t in l)
                {
                    transform.position = l[0].transform.position + ((l[1].transform.position - l[0].transform.position)/l.Length);
                    transform.position -= new Vector3(0, 0, Mathf.Abs((l[1].transform.position.x - l[0].transform.position.x) / l.Length));
                }
            }
            else
            {
                transform.position = l[0].transform.position;
            }
            transform.position -= new Vector3(0, -2, decal);

        }
        

    }
}
