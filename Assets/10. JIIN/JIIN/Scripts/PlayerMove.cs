using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �߷��� �����Ű�� �ʹ�
public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;

    // �ʿ� �Ӽ� �̵� �ӵ�
    public float speed = 10;
    // �ʿ� �Ӽ� �߷�(���ӵ�)
    public float gravity = -20;
    // ���� �ӵ�
    float yVelocity = 0;

    // ���� ī��Ʈ
    int jumpCount = 0;
    public int jumpingMax =2;
    CharacterController cc;

    // �ʿ�Ӽ� �����Ŀ�
    public float jumpPower = 5;
    // ���� ������ ���� ���
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
            // ������� �Է¿� ���� �յ��¿� �̵��ϰ� �ʹ�
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

            // ��ӿ ���� v = v0 + at
            yVelocity += gravity * Time.deltaTime;

            // �ٴڿ� 10cm ������ �ִٸ� ������ �Ǵ�����
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hitInfo;
            int layer = 1 << gameObject.layer;
            if (Physics.Raycast(ray, out hitInfo, 0.1f, ~layer) == false)
            {
                // ���߿� �ִ�
            }

            // ���� �ٴڿ� ��� �ִٸ�
            if (cc.collisionFlags == CollisionFlags.Below)
            {
                // ���� �ӵ��� 0���� ����
                yVelocity = 0;

                isjumping = false;
                jumpCount = 0;
            }
            // ����ڰ� ���� ��ư�� ������ �����ϰ� �ʹ�
            if (jumpCount < jumpingMax && Input.GetKeyDown(KeyCode.Z))
            {
                yVelocity = jumpPower;
                jumpCount++;
                anim.SetTrigger("Jump");
                //isjumping = true;
            }
            //// ���� �ӵ��� ��ȭ�� �ְ� �ʹ�
            dir.y = yVelocity;

            cc.Move(dir * speed * Time.deltaTime);
        }
    }
}
