using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=yjZ5mLNll5M
public class treat_drop : MonoBehaviour
{
    public GameObject TreatModel;
    private float health = 10f;
    public Transform transform;

    private void Update(){
        if(health<=0){
            // public void Die(){
            //     Destroy(gameObject);
            //     DropCoin();
            // }
        }
    }
    
    
    void DropCoin(){
        Vector3 position = transform.position;
        GameObject coin = Instantiate(TreatModel, position, Quaternion.identity);
    }
}