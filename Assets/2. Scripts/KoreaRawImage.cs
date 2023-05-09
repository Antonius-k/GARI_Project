using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoreaRawImage : MonoBehaviour
{
    public static KoreaRawImage Instance;
    public Texture[] eightDoImg;

    public Text localName;
    public Text SpotName;
    public GameObject localPannel;
    public GameObject NameSetPanel;    
    
    public GameObject NameSet_Jeju;
    public GameObject NameSet_Kangwon;
    public GameObject NameSet_Null;

    RawImage ri;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ri = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GyenggiImg()
    {
        ri.texture = eightDoImg[0];
    }

    public void KangwonImg()
    {
        ri.texture = eightDoImg[1];
    }

    public void ChungBukImg()
    {
        ri.texture = eightDoImg[2];

    }

    public void ChungNamImg()
    {
        ri.texture = eightDoImg[3];

    }

    public void KyeongBukImg()
    {
        ri.texture = eightDoImg[4];

    }

    public void KyeongNamImg()
    {
        ri.texture = eightDoImg[5];

    }

    public void JeonBukImg()
    {
        ri.texture = eightDoImg[6];

    }

    public void JeonNamImg()
    {
        ri.texture = eightDoImg[7];

    }

    public void JejuImg()
    {
        ri.texture = eightDoImg[8];

    }

    public void UlreungImg()
    {
        ri.texture = eightDoImg[9];

    }

    public void SeoulImg()
    {
        ri.texture = eightDoImg[10];

    }

    public void IncheonImg()
    {
        ri.texture = eightDoImg[11];

    }
    public void SejongImg()
    {
        ri.texture = eightDoImg[12];

    }
    public void DeaJeonImg()
    {
        ri.texture = eightDoImg[13];

    }
    public void DeaguImg()
    {
        ri.texture = eightDoImg[14];

    }
    public void KwangjuImg()
    {
        ri.texture = eightDoImg[15];

    }
    public void UlsanImg()
    {
        ri.texture = eightDoImg[16];

    }
    public void BusanImg()
    {
        ri.texture = eightDoImg[17];

    }
    public void ImgOut()
    {
        ri.texture = eightDoImg[18];

    }

    //-------------------------------------------------------------------------------

    public void GyenggiBtn()
    {
        localName.text = "��⵵";
        ri.texture = eightDoImg[0];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void KangwonBtn()
    {
        localName.text = "������";
        ri.texture = eightDoImg[1];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Kangwon.SetActive(true);
    }

    public void ChungBukBtn()
    {
        localName.text = "��û�ϵ�";
        ri.texture = eightDoImg[2];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);

    }

    public void ChungNamBtn()
    {
        localName.text = "��û����";
        ri.texture = eightDoImg[3];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void KyeongBukBtn()
    {
        localName.text = "���ϵ�";
        ri.texture = eightDoImg[4];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void KyeongNamBtn()
    {
        localName.text = "��󳲵�";
        ri.texture = eightDoImg[5];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void JeonBukBtn()
    {
        localName.text = "����ϵ�";
        ri.texture = eightDoImg[6];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void JeonNamBtn()
    {
        localName.text = "���󳲵�";
        ri.texture = eightDoImg[7];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void JejuBtn()
    {
        localName.text = "����Ư����ġ��";
        ri.texture = eightDoImg[8];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Jeju.SetActive(true);
    }

    public void UlreungBtn()
    {
        localName.text = "�︪��, ����";
        ri.texture = eightDoImg[9];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void SeoulBtn()
    {
        localName.text = "����Ư����";
        ri.texture = eightDoImg[10];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void IncheonBtn()
    {
        localName.text = "��õ������";
        ri.texture = eightDoImg[11];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }
    public void SejongBtn()
    {
        localName.text = "����Ư����ġ��";
        ri.texture = eightDoImg[12];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }
    public void DeaJeonBtn()
    {
        localName.text = "����������";
        ri.texture = eightDoImg[13];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }
    public void DeaguBtn()
    {
        localName.text = "�뱸������";
        ri.texture = eightDoImg[14];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }
    public void KwangjuBtn()
    {
        localName.text = "���ֱ�����";
        ri.texture = eightDoImg[15];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }
    public void UlsanBtn()
    {
        localName.text = "��걤����";
        ri.texture = eightDoImg[16];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }
    public void BusanBtn()
    {
        localName.text = "�λ걤����";
        ri.texture = eightDoImg[17];
        localPannel.SetActive(false);
        NameSetPanel.SetActive(true);
        NameSet_Null.SetActive(true);
    }

    public void SpotHanla()
    {
        SpotName.text = "�Ѷ��";
        NameSetPanel.SetActive(false);
    }
}
