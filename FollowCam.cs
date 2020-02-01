using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    void Update()
    {
        Vector3 Temp = Input.mousePosition;
        Temp.y = 0f;
        this.transform.position = Camera.main.ScreenToWorldPoint(Temp);
    }
    public void OnButtonDistory()
    {
        GameObject[] drawlines = GameObject.FindGameObjectsWithTag("Finish");
        for (int i = 0; i < drawlines.Length; i++)
        {
            Destroy(drawlines[i]);
        }
        
    }
}
