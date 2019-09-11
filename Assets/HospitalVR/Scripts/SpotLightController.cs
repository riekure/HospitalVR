using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour {

    private Light spotLight;  // ON/OFFするライト

    // Use this for initialization
    void Start ()
    {
        spotLight = GetComponent<Light>();
    }
    
    // Update is called once per frame
    void Update ()
    {

    }

    public void OnClickLightButton()
    {
        spotLight.enabled = !spotLight.enabled;
    }
}
