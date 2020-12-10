using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool IsInvisible = false;

    public float InvicibiltyFlashDelay = 0.5f;
    public float InvicibilityTimeAfterHit = 1f;

    public SpriteRenderer Graphics;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!IsInvisible)
        {
            currentHealth -= damage; // même chose que currentHealth = currentHealth - damage
            healthBar.SetHealth(currentHealth);
            IsInvisible = true;
            StartCoroutine(InviciblityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    public IEnumerator InviciblityFlash()
    {
        while(IsInvisible)
        {
            Graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvicibiltyFlashDelay);
            Graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvicibiltyFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(InvicibilityTimeAfterHit);
        IsInvisible = false;
    }

}



