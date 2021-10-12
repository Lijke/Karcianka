using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Cards")]
public abstract class Move : ScriptableObject
{
    public GameObject particleHit;
    public abstract void UseMove(Health playerHealth);
}
