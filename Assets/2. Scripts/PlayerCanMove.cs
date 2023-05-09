using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanMove : MonoBehaviour
{
    public PlayerMove pm;
    public GameObject writePanel;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if(writePanel.activeSelf == true)
        {
            pm.canMove = false;
        }
        if (writePanel.activeSelf == false)
        {
            pm.canMove = true;
        }
    }

    public void pmTrue()
    {
        pm.canMove = true;
    }

    public void pmFalse()
    {
        pm.canMove = false;
    }
}
