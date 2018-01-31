using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    // todo remove from inspector later 
    //[Range(0,1)][SerializeField] below doesn't need to be exposed to the inspector 
    float movementFactor; // 0 for not moved, 1 for fully moved 

    Vector3 startingPos;

	// Use this for initialization
	void Start () 
    {
        startingPos = transform.position; //get the transform (xyz start position) of the obstacle the script is attached to 
	}
	
	// Update is called once per frame
	void Update () 
    {
        // set movement factor 
        if (period <= Mathf.Epsilon) { return; } //protect against period == 0 (always use Mathf.Epsilon to compare floating point to 0)
        float cycles = Time.time / period; //this grows continually from 0

        const float tau = Mathf.PI * 2; //about 6.28 (double Pi obviously)
        float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to 1 

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
	}
}
