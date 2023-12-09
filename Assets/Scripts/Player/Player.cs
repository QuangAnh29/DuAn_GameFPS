using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float playerHP = 100;
    private bool isDead = false;

    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            playerHP -= damageAmount;


            if (playerHP <= 0)
            {
                isDead = true;
                if (AudioManager.instance.zombieChannel.isPlaying)
                {
                    AudioManager.instance.zombieChannel.Stop();
                }
                // Tắt các component điều khiển
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                Time.timeScale = 0f;

                PlayerManager.isGameOver = true;
                //gameObject.SetActive(false);
                AudioManager.instance.Play("Die");

            }
            else
            {
                Debug.Log("You Hit");
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
            TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
        }
    }
}
