using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "ScriptableObject/Player")]
public class Spaceship : ScriptableObject
{
    public int Hp;
    public float Velocity;
    public GameObject Bullet;
    public Sprite Sprite;
    public float ShootCooldown;
    public float SlowedVelocity = 2;
}


