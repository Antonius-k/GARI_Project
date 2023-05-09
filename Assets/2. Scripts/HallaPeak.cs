using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallaPeak : MonoBehaviour
{
    public GameObject hallaPeak;

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
            StartCoroutine(Notice2());
        }
    }

    IEnumerator Notice2()
    {
        hallaPeak.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        hallaPeak.SetActive(false);
    }
}
