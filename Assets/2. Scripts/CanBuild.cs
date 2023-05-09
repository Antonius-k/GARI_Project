using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBuild : MonoBehaviour
{
    public GameObject cantBuildHere;
    public GameObject btnSet;
    public GameObject[] StructureSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //btnSet.SetActive(true);
        }

        if (other.gameObject.tag != "Ground")
        {
            StartCoroutine(NoticeCant());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            StartCoroutine(NoticeCant());
        }

    }

    IEnumerator NoticeCant()
    {
        cantBuildHere.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        cantBuildHere.SetActive(false);
    }

    public void Select0()
    {
        GameObject buildStructure = Instantiate(StructureSet[0]);
        buildStructure.transform.position = transform.position;

        btnSet.SetActive(false);
        Destroy(gameObject);
    }

    public void Select1()
    {
        GameObject buildStructure = Instantiate(StructureSet[1]);
        buildStructure.transform.position = transform.position;

        btnSet.SetActive(false);
        Destroy(gameObject);
    }

    public void Select2()
    {
        GameObject buildStructure = Instantiate(StructureSet[2]);
        buildStructure.transform.position = transform.position;

        btnSet.SetActive(false);
        Destroy(gameObject);
    }

    public void Select3()
    {
        GameObject buildStructure = Instantiate(StructureSet[3]);
        buildStructure.transform.position = transform.position;

        btnSet.SetActive(false);
        Destroy(gameObject);
    }
    public void Select4()
    {
        GameObject buildStructure = Instantiate(StructureSet[4]);
        buildStructure.transform.position = transform.position;

        btnSet.SetActive(false);
        Destroy(gameObject);
    }

    public void Select5()
    {
        GameObject buildStructure = Instantiate(StructureSet[5]);
        buildStructure.transform.position = transform.position;

        btnSet.SetActive(false);
        Destroy(gameObject);
    }

    //public void Select6()
    //{
    //    GameObject buildStructure = Instantiate(StructureSet[6]);
    //    buildStructure.transform.position = transform.position;

    //    btnSet.SetActive(false);
    //    Destroy(gameObject);
    //}

    //public void Select7()
    //{
    //    GameObject buildStructure = Instantiate(StructureSet[7]);
    //    buildStructure.transform.position = transform.position;

    //    btnSet.SetActive(false);
    //    Destroy(gameObject);
    //}
}
