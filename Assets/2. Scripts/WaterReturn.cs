using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterReturn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject pp = other.gameObject;
            pp.transform.position = new Vector3(836, 90, -343.3f);
        }
    }
}
