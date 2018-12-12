using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour {

    public Hole red;
    public Hole blue;
    public Hole green;

    void onGUI()
    {
        string label = " ";

        // すべてのボールが入ったらラベルを表示
        if (red.InFallIn() && blue.InFallIn() && green.InFallIn())
        {
            label = "Fall in hole!";
        }
        GUI.Label(new Rect(0, 0, 100, 30), label);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
