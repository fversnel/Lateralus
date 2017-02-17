using System.Collections;
using System.Collections.Generic;
using Lateralus;
using UnityEngine;

public class ComplexNumberTest : MonoBehaviour {

    private ComplexNumber _rotation;

	// Use this for initialization
	void Awake () {
        _rotation = new ComplexNumber(1, 0);

        Debug.Log("-5 % 360 = " + new Angle(-5) * 10);
        Debug.Log("-5 is bigger than 60: " + ((-5).AsAngle() > 60.AsAngle()));

        var c1 = new ComplexNumber(1, 1);
        var c2 = new ComplexNumber(1, 1);
        Debug.Log(c1 + " * " + c2 + " = " + (c1 * c2));


        var c3 = new ComplexNumber(3, 4);
        var c4 = new ComplexNumber(1, 1);
        Debug.Log(c3 + " * " + c4 + " = " + (c3 * c4));

        var c5 = new ComplexNumber(1, -1);
        var c6 = new ComplexNumber(1, -1);
        Debug.Log(c5 + " * " + c6 + " = " + (c5 * c6));

	}
	
	// Update is called once per frame
	void Update () {
        ComplexNumber additionalRotation;
	    if (Input.GetKeyDown(KeyCode.D)) {
	        additionalRotation = new ComplexNumber(1, -1).Normalize();
	    } else {
	        additionalRotation = new ComplexNumber(1, 0);
	    }
        _rotation *= additionalRotation;
	}

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, _rotation.AsVector());
    }
}
