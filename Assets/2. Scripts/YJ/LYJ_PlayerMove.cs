using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* YJ ��� �߰�
 * 1 �ڷ���Ʈ UI Ŭ�� ��
 */
public class LYJ_PlayerMove : MonoBehaviour
{
    public static LYJ_PlayerMove instance;

    #region move field
    // �ʿ� �Ӽ� �̵� �ӵ�
    public float speed = 10;
    // �ʿ� �Ӽ� �߷�(���ӵ�)
    public float gravity = -20;
    // ���� �ӵ�
    float yVelocity = 0;
    // �̵�
    public bool canMove = true;
    #endregion

    #region jump field
    // ���� ī��Ʈ
    int jumpCount = 0;
    public int jumpingMax =2;
    // �ʿ�Ӽ� �����Ŀ�
    public float jumpPower = 5;
    // ���� ������ ���� ���
    bool isjumping = false;
    #endregion

    #region assign
    CharacterController cc;
    public Vector3 dir;
    public GameObject writePanel;
    Animator anim;
    public ButtonScript btnScript;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        #region restrict MOVE
        if (writePanel.activeSelf == true)
        {
            canMove = false;
        }
        else if (writePanel.activeSelf == false)
        {
            canMove = true;
        }
        #endregion

        if (canMove == true)
        {
            #region regarding MOVE
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h != 0 || v != 0)
            {
                anim.SetTrigger("Move");
            }
            else
            {
                anim.SetTrigger("Idle");
            }

            dir = new Vector3(h, 0, v).normalized;
            transform.LookAt(transform.position + dir);
            yVelocity += gravity * Time.deltaTime;
            #endregion

            #region reegarding JUMP
            // �ٴڿ� 10cm ������ �ִٸ� ������ �Ǵ�����
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hitInfo;
            int layer = 1 << gameObject.layer;
            if (Physics.Raycast(ray, out hitInfo, 0.1f, ~layer) == false)
            {
                isjumping = true;
            }

            if (cc.collisionFlags == CollisionFlags.Below)
            {
                yVelocity = 0;

                isjumping = false;
                jumpCount = 0;
            }
            if (jumpCount < jumpingMax && Input.GetKeyDown(KeyCode.Z))
            {
                yVelocity = jumpPower;
                jumpCount++;
                anim.SetTrigger("Jump");
                isjumping = true;
            }
            dir.y = yVelocity;
            #endregion

            cc.Move(dir * speed * Time.deltaTime);
        }
        

    }
}
