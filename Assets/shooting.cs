using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    [SerializeField] private AudioSource gunShotSFX;
    public Animator myAnimator;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        Vector2 scale = transform.localScale;
        if(rotation.x < 0){
            scale.y = -1;
        }
        else if(rotation.x > 0){
            scale.y = 1;
        }
        transform.localScale = scale;
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            myAnimator.SetTrigger("isShot");
            gunShotSFX.Play();
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);

        }
    }
}
