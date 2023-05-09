using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SameName : MonoBehaviour
{
    public GameObject parentBuilding;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.name = parentBuilding.name;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.name = parentBuilding.name;
    }
}
