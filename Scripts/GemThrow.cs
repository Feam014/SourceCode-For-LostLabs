using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemThrow : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        StartCoroutine(BulletPlay());
    }

    IEnumerator BulletPlay()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        yield return new WaitForSeconds(9999999);
    }
}
