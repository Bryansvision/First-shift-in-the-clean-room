using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tablet : MonoBehaviour
{
    private bool flipped;
    public MeshRenderer tabletRenderer;
    public TextMeshProUGUI tableText;
    public Animator tabletAnimator;


    public void tablet(InputAction.CallbackContext context)
    {
        if (context.performed && !flipped)
        {
            tabletRenderer.enabled = true;
            tableText.enabled = true;
            tabletAnimator.SetTrigger("Flip");
            flipped = true;
            
        }else if (context.performed && flipped)
        {
            StartCoroutine(flippingDown());
        }
    }


    IEnumerator flippingDown()
    {
        flipped = false;
        tabletAnimator.SetTrigger("Unflip");
        yield return new WaitForSeconds(2);
        
        tabletRenderer.enabled = false;
        tableText.enabled = false;
        yield break;
    }

}
