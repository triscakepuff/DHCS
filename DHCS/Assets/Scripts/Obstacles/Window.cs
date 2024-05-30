using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private GameObject windowObs;
    [SerializeField] private Material tempIndicator;
    private Renderer windowRenderer;
    private bool windowBroken = false;
    private bool isInWindow = false;
    public Collider2D collider;
    private GameController HP;
    private PlayerStateManager player;

    // Start is called before the first frame update
    void Start()
    {
        windowRenderer = windowObs.GetComponent<Renderer>();
        GameObject Theodore = GameObject.Find("Theodore");
        if (Theodore != null)
        {
            // Get the GameController script attached to Theodore
            HP = Theodore.GetComponent<GameController>();
            collider = GetComponent<CircleCollider2D>();
            player = Theodore.GetComponent<PlayerStateManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(windowBroken)
        {
            collider.enabled = false;
        }
    }

    private IEnumerator ChangeMaterialDelayed(Material newMaterial, float delay)
    {
        yield return new WaitForSeconds(delay);
        windowRenderer.material = newMaterial;
        windowBroken = true;
        if(isInWindow && HP != null && player.currentState != player.hideState)
        {
            HP.currHP--;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string currentTag = gameObject.tag;
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeMaterialDelayed(tempIndicator, 0.5f));
            isInWindow = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInWindow = false;
        }
    }
}
