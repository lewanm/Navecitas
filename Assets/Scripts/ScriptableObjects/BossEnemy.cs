using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/Enemy/Boss")]
public class BossEnemy : ScriptableObject
{
    public float Velocity;
    public GameObject Bullet;
    public Sprite Sprite;
    public int InitialHp;
    public float ShootCooldown;
}
