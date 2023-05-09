using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* YJ 기능 추가
 * 1 텔레포트 UI 클릭 후
 */
public class LYJ_PlayerMove : MonoBehaviour
{
    public static LYJ_PlayerMove instance;

    #region move field
    // 필요 속성 이동 속도
    public float speed = 10;
    // 필요 속성 중력(가속도)
    public float gravity = -20;
    // 수직 속도
    float yVelocity = 0;
    // 이동
    public bool canMove = true;
    #endregion

    #region jump field
    // 점프 카운트
    int jumpCount = 0;
    public int jumpingMax =2;
    // 필요속성 점프파워
    public float jumpPower = 5;
    // 점프 중인지 여부 기억
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
            // 바닥에 10cm 떨어져 있다면 점프로 판단하자
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
