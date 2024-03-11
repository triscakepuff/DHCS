using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private GameObject windowObs;
    [SerializeField] private Material tempIndicator;
    private Renderer windowRenderer;
    // Start is called before the first frame update
    void Start()
    {
        windowRenderer = windowObs.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ChangeMaterialDelayed(Material newMaterial, float delay)
    {
        yield return new WaitForSeconds(delay);
        windowRenderer.material = newMaterial;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string currentTag = gameObject.tag;
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeMaterialDelayed(tempIndicator, 0.5f));
        }
    }
}
