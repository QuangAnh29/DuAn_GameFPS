using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public ZombieHand zombieHand;

    public int damage;
    private void Start()
    {
        zombieHand.damage = damage;
    }
}
