// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
//using UnityEngine.UI;

public class ratKing_health : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 150f;
    public ratKing_healthbar Healthbar;
    public GameObject[] itemDrops;
    public float damaged = 0.2f;
    public int scoreNum = 0;
    private bool isDead = false;
    public Animator animator;

    // public GameObject enemy;

    public bool isInvulnerable = false;

    public GameObject ratKing;
    private FlashDamage flashDamage;

    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;


    void Start()
    {

        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints);

        // m_SpriteRenderer = GetComponent<SpriteRenderer>();
        // ratKing = GameObject.Find("RatKing");
        m_SpriteRenderer = ratKing.GetComponent<SpriteRenderer>();
        flashDamage = GetComponent<FlashDamage>();

        // Debug.Log(ratKing);
        // Debug.Log(m_SpriteRenderer);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AttackBox"))
        {
            TakeDamage(damaged);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        flashDamage.FlashOnDamage();

        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints);

        if (Hitpoints <= 75)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
        if (Hitpoints <= 0 && !isDead)
        {
            isDead = true;
            animator.SetBool("isDead", isDead);
            Invoke("ItemDrop", 1.5f);
            //StartCoroutine(PlayDeathAnimationAndDestroy());
        }
    }

    //private IEnumerator PlayDeathAnimationAndDestroy()
    //{
    //    animator.Play("rat_king_death", 0, 0.9f);
    //    yield return new WaitForSeconds(1.5f); // Adjust the delay time if needed
    //    Destroy(gameObject);
    //    ItemDrop();
    //}

    private void ItemDrop()
    {
        Destroy(gameObject);
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
        Invoke("Credits", 2);
    }

    private void Credits()
    {
        SceneManager.LoadScene(12);
    }
    //public void ScoreCollection()
    //{
    //    scoreNum = updater.scoreCount += 100;                 // updates the score counter
    //}
}