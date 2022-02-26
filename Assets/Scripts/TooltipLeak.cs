using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipLeak : MonoBehaviour
{
    public Animator tooltipAnimator;
    public SpriteRenderer spriteRenderer;

    public enum TooltipStates
    {
        Warning,
        Spacebar
    }

    private TooltipStates tooltipState = TooltipStates.Warning;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tooltipAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (tooltipState)
        {
            case TooltipStates.Warning:
                tooltipAnimator.Play("Warning", -1);
                break;

            case TooltipStates.Spacebar:
                tooltipAnimator.Play("Spacebar", -1);
                break;
        }
    }

    public IEnumerator AnimateScaleAsBounce(float fromScaleX, float toScaleX, float fromScaleY, float toScaleY, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float newScaleX = Mathf.Lerp(fromScaleX, toScaleX, Easing.Elastic.Out(elapsedTime / duration));
            float newScaleY = Mathf.Lerp(fromScaleY, toScaleY, Easing.Elastic.Out(elapsedTime / duration));

            transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);

            elapsedTime += Time.deltaTime;
            yield return 0;
        }

        transform.localScale = new Vector3(toScaleX, toScaleY, transform.localScale.z);
        yield return 0;
    }

    public void ShowTooltip()
    {
        spriteRenderer.enabled = true;
    }

    public void HideTooltip()
    {
        spriteRenderer.enabled = false;
    }

    public void SetTooltipState(TooltipStates newTooltipState)
    {
        tooltipState = newTooltipState;
    }

}
