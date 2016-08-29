using UnityEngine;
using System.Collections;

public class NextLayer : MonoBehaviour {

    public static int index = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingOrder = index;
        index++;
	}
}
