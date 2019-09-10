using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSEController : MonoBehaviour 
{

    private AudioSource cupDropSE;  // 転がる音

    // Use this for initialization
    void Start () 
    {
        cupDropSE = GetComponent<AudioSource>();
    }

    // ものとぶつかったときに音を鳴らす
    private void OnCollisionEnter(Collision other)
    {
        // 音を鳴らす
        cupDropSE.PlayOneShot(cupDropSE.clip);
    }
}
