using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : MonoBehaviour {
    public GameObject cube;
    void Start() {

    }

    void Update() {
        if (cube != null) {
            var p = cube.transform.position;
            cube.transform.position = new Vector3(p.x + 0.1F, p.y, p.z);
            if (p.x > 0F) {
                Destroy(cube);
            }
        }
    }
}
