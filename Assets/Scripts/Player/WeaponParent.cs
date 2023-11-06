using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    public bool WillAttack {get; private set;}
    public Transform circleOrigin;
    public float radius;
    public void ResetwillAttack(){
        WillAttack = false;
    }

    private void Update()
    {
        // if(WillAttack){
        //     return;
        // }
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if(direction.x < 0){
            scale.y = -1;
        }
        else if(direction.x > 0){
            scale.y = 1;
        }
        transform.localScale = scale;
        // if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180){
        //     weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        // }
        // else{
        //     weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        // }
    }
    public void Attack(){
        if(attackBlocked){
            return;
        }

        animator.SetTrigger("Attack");
        WillAttack = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }
    private IEnumerator DelayAttack(){
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectCollider(){
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius)){
            Debug.Log(collider.name);
        }
    }
}
