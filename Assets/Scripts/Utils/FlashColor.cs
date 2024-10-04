using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color flashColor = Color.red;
    public float duration = .1f;

    private Tween _currentTween;

    private void OnValidate() {

        var spriteList = transform.GetComponentsInChildren<SpriteRenderer>();
        spriteRenderers = new List<SpriteRenderer>();

        foreach (var sprite in spriteList) 
        {
            spriteRenderers.Add(sprite);
        }
        
    }

    private void CheckTween()
    {
        if(_currentTween != null) 
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(element => element.color = Color.white);   
        }

    }

    public void Flash()
    {
        CheckTween();
        spriteRenderers.ForEach(sprite => sprite.DOColor(flashColor, duration).SetLoops(2, LoopType.Yoyo));
    }
}
