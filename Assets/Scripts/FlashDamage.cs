using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    public Material flashMaterial;
    private Material originalMaterial;
    private Renderer renderer;
    // Start is called before the first frame update
    private void Start()
    {
       renderer = GetComponent<Renderer>();
       originalMaterial = renderer.material;
    }


    public void FlashOnDamage()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        renderer.material = flashMaterial;
        yield return new WaitForSeconds(0.1f);
        renderer.material = originalMaterial;
    }
}
