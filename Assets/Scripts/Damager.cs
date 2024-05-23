using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [Range(0, 1)] public float damage;
    private void Start()
    {
        damage = .1f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Healthbar healthbar = FindObjectOfType<Healthbar>();
            healthbar.bar.fillAmount -= damage;
        }
    }
}
