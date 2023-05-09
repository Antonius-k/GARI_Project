using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : MonoBehaviour
{
    public GameObject possible;
    public GameObject impossible;
    public GameObject buildStructure;

    public bool canBuild = false;

    // Start is called before the first frame update
    void Start()
    {
        possible.SetActive(false);
        impossible.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            possible.SetActive(true);
            impossible.SetActive(false);

            canBuild = true;
        }

        if(other.gameObject.tag != "Ground")
        {
            possible.SetActive(false);
            impossible.SetActive(true);

            canBuild = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            possible.SetActive(false);
            impossible.SetActive(true);

            canBuild = false;
        }

    }
}
