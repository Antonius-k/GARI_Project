using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallaName : MonoBehaviour
{
    public GameObject HallaNotice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Notice());
        }
    }

    IEnumerator Notice()
    {
        HallaNotice.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        HallaNotice.SetActive(false);
    }
}
