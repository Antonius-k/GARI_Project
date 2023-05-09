using UnityEngine;
using System.Collections;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 20f;

    void Update() {
        transform.Rotate(new Vector3(0, 90, 0), speed * Time.deltaTime, Space.World);
    }
}