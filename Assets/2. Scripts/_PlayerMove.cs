using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class _PlayerMove : MonoBehaviourPun
{
    public float speed = 10;
    //public GameObject camcam;

    Animator anim;
    Rigidbody rigid;

    Vector3 dir;
    bool isBorder;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        //if(photonView.IsMine == true)
        //    camcam.SetActive(true);
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    void StopToWall()
    {
        isBorder = Physics.Raycast(transform.position, transform.forward, 1, LayerMask.GetMask("Wall"));
    }

    private void FixedUpdate()
    {
        FreezeRotation();
        StopToWall();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            dir = new Vector3(h, 0, v).normalized;
            //dir = transform.TransformDirection(new Vector3(0, 60, 0));

            if (!isBorder)
                transform.position += dir * speed * Time.deltaTime;
            //transform.LookAt(transform.position + dir);
            //transform.forward = Camera.main.transform.forward;

            anim.SetBool("isWalk", dir != Vector3.zero);

            //transform.forward = new Vector3(0, 50, 90);

            transform.LookAt(transform.position + dir);
        }
    }

    
}
