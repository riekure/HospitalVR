using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPanelController : MonoBehaviour {
    public GameObject mainCamera;
    public GameObject switchPlane_1;  // 視点UIの対象Plane
    public GameObject targetLight;    // 操作対象のライト

    public Material[] _material;     // 対象ボタンの色 0:通常/1:ヒット

    public SpriteRenderer switchPlaneSprite_1;

    public Sprite[] pointer;         // ポインター画像
    public float gazeTimeCount = 3.0f;      // 確定までの時間(秒)

    void Start()
    {
        Debug.Log("Switch Panel Controller is started");
    }

    void Update()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.black);     // Sceneでのみ線が見える

            if (hit.collider.gameObject.tag == "SwitchUI")          // 視点UIの対象かをタグで判定
            {
                Debug.Log("hit");
                if (CheckHitGameObject(hit, switchPlane_1))
                {
                    switchPlane_1.GetComponent<Renderer>().material = _material[1];   // ヒットの色
                    if (DrawSpriteFromGazeTimeCount(switchPlaneSprite_1))
                    {
                        targetLight.SetActive(!targetLight.activeSelf);     // 状態を反転
                        gazeTimeCount = 3.0f;
                    }
                }
            }
            else
            {
                gazeOff();
            }
        }
        else
        {
            gazeOff();
        }
    }

    public void gazeOff()
    {
        switchPlane_1.GetComponent<Renderer>().material = _material[0];       // 通常の色
        switchPlaneSprite_1.sprite = pointer[0];
        gazeTimeCount = 3.0f;
    }

    public bool CheckHitGameObject(RaycastHit hit, GameObject obj)
    {
        bool result = false;
        if (hit.collider.gameObject == obj)
        {
            result = true;
        }
        return result;
    }

    // 注視カウントの値によりポインタ画像を変更
    public bool DrawSpriteFromGazeTimeCount(SpriteRenderer spr)
    {
        bool result = false;

        if (gazeTimeCount > 0)
        {
            int idx = 6 - (int)(gazeTimeCount * 10) / 5;
            spr.sprite = pointer[idx];
            gazeTimeCount -= Time.deltaTime;
        }
        else
        {
            result = true;
            spr.sprite = pointer[0];
        }
        return result;
    }
}
