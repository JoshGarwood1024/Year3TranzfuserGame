using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float fireForce = 20f;
    public Transform firePoint;

    public Slider pistolSlider;
    public Slider shotgunSlider;

    private Rigidbody2D rb;
    private Vector2 mousePos;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Fire()
    {
        if(pistolSlider.value >= 0.95f)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);

            pistolSlider.value = 0;
        }

    }

    public void Shotgun()
    {
        if (shotgunSlider.value >= 0.95f)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position + (firePoint.right * 0.4f), transform.rotation * Quaternion.Euler(0, 0, 10));
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position - (firePoint.right * 0.4f), transform.rotation * Quaternion.Euler(0, 0, -10));

            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
            bullet2.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
            bullet3.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);

            shotgunSlider.value = 0;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Shotgun();
        }

        if(shotgunSlider.value < shotgunSlider.maxValue)
        {
            shotgunSlider.value += 0.005f;
        }

        if (pistolSlider.value < pistolSlider.maxValue)
        {
            pistolSlider.value += 0.2f;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
