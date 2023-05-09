using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 중력을 적용시키고 싶다
public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;

    // 필요 속성 이동 속도
    public float speed = 10;
    // 필요 속성 중력(가속도)
    public float gravity = -20;
    // 수직 속도
    float yVelocity = 0;

    // 점프 카운트
    int jumpCount = 0;
    public int jumpingMax =2;
    CharacterController cc;

    // 필요속성 점프파워
    public float jumpPower = 5;
    // 점프 중인지 여부 기억
    bool isjumping = false;

    public Vector3 dir;
    public GameObject writePanel;

    Animator anim;

    public bool canMove = true;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        //if (writePanel.activeSelf == true)
        //{
        //    canMove = false;
        //}
        //else if (writePanel.activeSelf == false)
        //{
        //    canMove = true;
        //}


        if (canMove == true)
        {
            // 사용자의 입력에 따라 앞뒤좌우 이동하고 싶다
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h != 0 || v != 0)
            {
                //print("stop");
                anim.SetTrigger("Move");
            }
            else
            {
                anim.SetTrigger("Idle");
            }

            dir = new Vector3(h, 0, v).normalized;

            //dir = Camera.main.transform.TransformDirection(dir);

            transform.LookAt(transform.position + dir);

            //transform.position += dir * speed * Time.deltaTime;
            //dir *= speed;

            // 등가속운동 공식 v = v0 + at
            yVelocity += gravity * Time.deltaTime;

            // 바닥에 10cm 떨어져 있다면 점프로 판단하자
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hitInfo;
            int layer = 1 << gameObject.layer;
            if (Physics.Raycast(ray, out hitInfo, 0.1f, ~layer) == false)
            {
                // 공중에 있다
            }

            // 만약 바닥에 닿아 있다면
            if (cc.collisionFlags == CollisionFlags.Below)
            {
                // 수직 속도를 0으로 하자
                yVelocity = 0;

                isjumping = false;
                jumpCount = 0;
            }
            // 사용자가 점프 버튼을 누르면 점프하고 싶다
            if (jumpCount < jumpingMax && Input.GetKeyDown(KeyCode.Z))
            {
                yVelocity = jumpPower;
                jumpCount++;
                anim.SetTrigger("Jump");
                //isjumping = true;
            }
            //// 수직 속도에 변화를 주고 싶다
            dir.y = yVelocity;

            cc.Move(dir * speed * Time.deltaTime);
        }
    }
}
