using UnityEngine;
using System.Collections;

public class LightShowUp : MonoBehaviour {

    public float intensityStep = 0.05f;
    Light light;
	// Use this for initialization
	void Start () {
        light = this.GetComponent<Light>();
        light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (light.intensity < 1.0f) {
            light.intensity += this.intensityStep;
        }
	}
}
