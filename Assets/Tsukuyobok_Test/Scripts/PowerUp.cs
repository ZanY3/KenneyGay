using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type { Health, Speed };
    public Type powerUpType;
    public float amount = 20f;
    public float duration = 5f; // для временных бонусов

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() is PlayerController player)
        {
            Apply(player);
            Destroy(gameObject);
        }
    }

    void Apply(PlayerController player)
    {
        switch (powerUpType)
        {
            case Type.Health:
                player.TakeDamage(-amount); // лечение
                break;
            case Type.Speed:
                StartCoroutine(SpeedBoost(player));
                break;
        }
    }

    System.Collections.IEnumerator SpeedBoost(PlayerController player)
    {
        player.moveSpeed += amount;
        yield return new WaitForSeconds(duration);
        player.moveSpeed -= amount;
    }
}
