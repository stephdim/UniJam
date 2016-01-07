using UnityEngine;
using System.Collections;

public class RotateOnKeyPressed : MonoBehaviour {


    public void RotateDown() {

        transform.Rotate(new Vector3(0, 0, -60));

    }

    public void RotateUp() {

        transform.Rotate(new Vector3(0, 0, 60));

    }
}
