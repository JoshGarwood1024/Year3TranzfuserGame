using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharge : Enemy
{
    public float chargeSpeed = 5f;
    public float chargeDuration = 2.0f;

    public LineRenderer chargeIndicator;

    private float journeyLength;
    private float startTime;
    private Vector3 startPos;

    private Vector3 targetLoc;

    private bool isCharging = false;

    public override void Start()
    {
        base.Start();

        GameObject lr = new GameObject("RocketLineRenderer");
        lr.transform.SetParent(transform);
        chargeIndicator = lr.AddComponent<LineRenderer>();

        chargeIndicator.enabled = false;
        StartCoroutine(ChargeRoutine());

        startPos = transform.position;
    }

    protected override void Update()
    {
        base.Update();

        if (isCharging)
        {
            float distanceCovered = (Time.time - startTime) * 25;
            float journeyFraction = distanceCovered / journeyLength;

            journeyFraction = Mathf.Clamp01(journeyFraction);

            transform.position = Vector3.Slerp(startPos, targetLoc, journeyFraction);

            if (Vector3.Distance(transform.position, targetLoc) < 3) Destroy(gameObject);
        }

    }

    IEnumerator ChargeRoutine()
    {
        chargeIndicator.enabled = true;

        chargeIndicator.SetPosition(0, transform.position);
        chargeIndicator.SetPosition(1, player.transform.position);

        targetLoc = player.transform.position;

        yield return new WaitForSeconds(chargeDuration);

        isCharging = true;
        chargeIndicator.enabled = false;

        Vector3 dir = targetLoc - transform.position;
        journeyLength = Vector3.Distance(startPos, targetLoc);
        startTime = Time.time;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //play explosion animation or something
            Destroy(gameObject);
        }
    }
}
