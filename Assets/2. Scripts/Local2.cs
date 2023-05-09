using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Local2 : MonoBehaviour
{
    public Dropdown local1;
    public Dropdown local2_DD_Busan;

    public GameObject l2_Busan;
    public GameObject l2_Fail;


    public GameObject[] Local3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(local1.value == 16)
        {
            l2_Busan.SetActive(true);
            l2_Fail.SetActive(false);
        }
        else
        {
            l2_Busan.SetActive(false);
            l2_Fail.SetActive(true);
        }

        if(local2_DD_Busan.value == 0)
        {
            Local3[0].SetActive(true);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 1)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(true);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 2)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(true);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 3)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(true);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 4)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(true);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 5)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(true);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 6)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(true);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 7)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(true);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 8)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(true);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 9)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(true);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 10)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(true);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 11)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(true);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 12)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(true);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 13)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(true);
            Local3[14].SetActive(false);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 14)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(true);
            Local3[15].SetActive(false);
        }
        else if (local2_DD_Busan.value == 15)
        {
            Local3[0].SetActive(false);
            Local3[1].SetActive(false);
            Local3[2].SetActive(false);
            Local3[3].SetActive(false);
            Local3[4].SetActive(false);
            Local3[5].SetActive(false);
            Local3[6].SetActive(false);
            Local3[7].SetActive(false);
            Local3[8].SetActive(false);
            Local3[9].SetActive(false);
            Local3[10].SetActive(false);
            Local3[11].SetActive(false);
            Local3[12].SetActive(false);
            Local3[13].SetActive(false);
            Local3[14].SetActive(false);
            Local3[15].SetActive(true);
        }
       
    }
}
