using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        //target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameObject.FindWithTag("Player").transform;
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //Vector3 dir = new Vector3(h, 0, v).normalized;

        //transform.position += dir * 9.2f * Time.deltaTime;

        transform.position = new Vector3(target.transform.position.x + 6000, 200, target.transform.position.z);
    }
}
