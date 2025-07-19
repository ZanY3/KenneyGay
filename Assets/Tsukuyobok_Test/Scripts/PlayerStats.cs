using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Roguelike/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public float baseHealth = 100f;
    public float baseSpeed = 5f;
    public float baseDamage = 10f;

    [Header("Upgrade Levels")]
    public int healthLevel;
    public int speedLevel;
    public int damageLevel;

    public float GetMaxHealth() => baseHealth + healthLevel * 20;
    public float GetSpeed() => baseSpeed + speedLevel * 0.5f;
    public float GetDamage() => baseDamage + damageLevel * 2f;
}
