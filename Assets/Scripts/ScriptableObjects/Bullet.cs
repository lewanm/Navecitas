using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;

[CreateAssetMenu(fileName = "New Bullet", menuName = "ScriptableObject/Bullet")]
public class Bullet : ScriptableObject
{
    public int Damage;
    public float Velocity = 5;
    public Sprite Sprite;
    public bool Homming = false;



}
