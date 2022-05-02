using UnityEngine;
using System.Collections;

public class VoiceAnimator : MonoBehaviour {

    public AudioSource voice;
    public Light light;

    public float sampleThreshold = 0.0001f;
    public float inputBottom = 0.001f;
    public float inputTop = 0.4f;

    public float lightBottom = 0.5f;
    public float lightTop = 2.0f;

    float lightIntensity;

    // Use this for initialization
    void Start () {
        AudioSource voice = GetComponent<AudioSource>();
        this.lightIntensity = lightBottom;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("1")) {
            this.light.intensity = 0.5f;
        } else if (Input.GetKeyDown("2")) {
            this.light.intensity = 5.0f;
        }
        this.light.intensity = this.lightIntensity;
    }

    public void onData(float[] data,int channels, int sampleRate) {
        /*print("data.Length:" + data.Length);
        print("channels:" + channels);
        print("sampleRate" + sampleRate);
        */
        float value = 0.0f;
        foreach(float sample in data)
        {
            value += (sample > this.sampleThreshold) ? sample : 0.0f;
        }
        value /= data.Length;
        value = Mathf.Abs(value);
        value = value - this.inputBottom;
        value = Mathf.Clamp(value - this.inputBottom, 0, this.inputTop - this.inputBottom) / (this.inputTop - this.inputBottom);
        this.lightIntensity = this.lightBottom + (value * (this.lightTop - this.lightBottom));
        //print(value);
    }
}
