using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{
    public float gemsleft;
    public Text texty;
    public GemThrow gemy;

    // Start is called before the first frame update
    void Start()
    {
        gemsleft = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gemsleft <= 0f)
        {
            gemsleft = 0f;
            gemy.enabled = false;
        }

        if (gemsleft >= 1f)
        {
            gemy.enabled = true;
        }

        texty.text = gemsleft.ToString("0");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gemsleft -= 1f;
        }
    }
}
