using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    public Material flashMaterial;
    private Material originalMaterial;
    Renderer objRenderer;
    // Start is called before the first frame update
    private void Start()
    {
       objRenderer = GetComponent<Renderer>();
       originalMaterial = objRenderer.material;
    }


    public void FlashOnDamage()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        objRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.1f);
        objRenderer.material = originalMaterial;
    }
}
