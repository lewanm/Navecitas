using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pattern", menuName = "ScriptableObject/Pattern")]
public class Pattern : ScriptableObject
{
    public float ShootCD;
    public int BulletAmount;
    public int Divider;
    public float VelocityReducer;
    public float VelocityMultiplier;

}
