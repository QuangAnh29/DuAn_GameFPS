using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;

    public bool isDead = false;


    private UnityEngine.AI.NavMeshAgent navAgent;

    private float timeUntilDisappear = 5.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        /*if (isDead)
        {
            return;
        }*/
        if (HP <= 0)
        {
            isDead = true;
            int RandomValue = Random.Range(0, 2);

            if (RandomValue == 0)
            {
                animator.SetTrigger("Die1");

            }
            else
            {
                animator.SetTrigger("Die2");
            }

           StartCoroutine(DisappearAfterDelay());
            AudioManager.instance.Play("Zombie_Death");

        }
        else
        {
            animator.SetTrigger("Damage");
            AudioManager.instance.Play("Zombie_Hurt");
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(timeUntilDisappear);

        // Sau 5 giây, hủy đối tượng Zombie
        Destroy(gameObject);
    }
}
