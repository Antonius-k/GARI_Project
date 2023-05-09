using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baegi : MonoBehaviour
{
    public GameObject baegi;

    //float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BaegiSet());
    }

    // Update is called once per frame
    void Update()
    {
        //currentTime += Time.deltaTime;

        //if (currentTime > 0.5f)
        //{
        //    baegi.SetActive(false);
        //    currentTime = 0;
        //}
    }

    IEnumerator BaegiSet()
    {
        baegi.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        baegi.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        
    }
}
