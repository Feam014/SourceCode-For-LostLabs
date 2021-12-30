using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [Range(1, 10)]
    [SerializeField] float perfectFactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 perfectPosition = Vector3.Lerp(transform.position, playerPosition, perfectFactor * Time.fixedDeltaTime);
        transform.position = playerPosition;
    }
}
