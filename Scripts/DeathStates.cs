using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathStates : MonoBehaviour
{
    public CharacterMovement movehealth;
    [SerializeField] float healthment;
    public static float livesstock = 9f;
    [SerializeField] Text livesMtocks;

    private bool printDone;

    // Start is called before the first frame update
    void Start()
    {
        printDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthment = movehealth.health;

        livesMtocks.text = livesstock.ToString("0");

        if (healthment <= 0f && !printDone)
        {
            livesstock -= 1f;
            printDone = true;
        }
    }
}
