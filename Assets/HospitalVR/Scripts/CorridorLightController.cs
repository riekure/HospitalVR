using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorLightController : MonoBehaviour {

    private Light corridorLight;    // 点灯・消灯対象になるライト

    public float timeOut = 2.0f;    // 点灯・消灯判定周期

    private float timeElapsed;

    public float threshold = 0.5f;  // 点灯・消灯切替基準

    // Use this for initialization
    void Start () {
        corridorLight = GetComponent<Light>();
    }
    
    // Update is called once per frame
    void Update () {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            float rnd = Random.value;

            if (rnd < threshold)
            {
                corridorLight.enabled = !corridorLight.enabled; // 点灯状態を反転
            }
            timeElapsed = 0.0f;
        }
    }
}
