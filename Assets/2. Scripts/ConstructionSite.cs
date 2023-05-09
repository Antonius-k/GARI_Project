using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConstructionSite : MonoBehaviour
{
    public GameObject btnSet;
    public GameObject cantBuildHere;
    public ParticleSystem SmokeEffect;

    //public _PlayerMove pm2;
    public GameObject[] StructureSet;

    void Update()
    {
        this.transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground")
        {
            btnSet.SetActive(false);
            cantBuildHere.SetActive(true);
            //StartCoroutine(NoticeCant());
        }
        if (other.gameObject.tag == "Ground")
        {
            btnSet.SetActive(true);
            //pm2.canMove = true;
            cantBuildHere.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            btnSet.SetActive(false);
            cantBuildHere.SetActive(true);
            //StartCoroutine(NoticeCant());
        }
        if (other.gameObject.tag != "Ground")
        {
            btnSet.SetActive(true);
            cantBuildHere.SetActive(false);
            //StartCoroutine(NoticeCant());
        }
    }

    //IEnumerator NoticeCant()
    //{
    //    cantBuildHere.SetActive(true);
    //    yield return new WaitForSeconds(2.0f);
    //    cantBuildHere.SetActive(false);
    //}

    public void Selec0()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("0_Restaurant", transform.position, Quaternion.identity);        

        ParticleSystem SE = Instantiate(SmokeEffect);
        SE.transform.position = transform.position;

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Selec1()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("1_Cafe", transform.position, Quaternion.identity);


        buildStructure.transform.position = transform.position;

        ParticleSystem SE = Instantiate(SmokeEffect);
        SE.transform.position = transform.position;

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Selec2()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("Hotel_Build", transform.position, Quaternion.identity);

        SmokeEffect.Play();

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Selec3()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("Museum_Build", transform.position, Quaternion.identity);

        ParticleSystem SE = Instantiate(SmokeEffect);
        SE.transform.position = transform.position;

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Selec4()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("ConcertHall_Build", transform.position, Quaternion.identity);

        ParticleSystem SE = Instantiate(SmokeEffect);
        SE.transform.position = transform.position;

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Selec5()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("Park_Build", transform.position, Quaternion.identity);

        SmokeEffect.Play();
        Destroy(gameObject, SmokeEffect.duration);

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Selec6()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("HistoricSite_Build", transform.position, Quaternion.identity);

        ParticleSystem SE = Instantiate(SmokeEffect);
        SE.transform.position = transform.position;

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Selec7()
    {
        GameObject buildStructure = PhotonNetwork.Instantiate("Beach_Build", transform.position, Quaternion.identity);

        SmokeEffect.Play();

        btnSet.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
