using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is basically to store data about another enemy type, specifically this is for
// the flying enemies in Level 2
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]

// This is a ScriptableObject, it can be accessed publicly and
// is independent of any script made variables
public class EnemyData : ScriptableObject
{
    public int hp;
    public int damage;
    public float speed;
}
