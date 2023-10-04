using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteLevelController : MonoBehaviour
{
    [SerializeField] List<Sprite> LevelsSprites;
    [SerializeField] List<RuntimeAnimatorController> LevelsAnimatorControllers;

    SpriteRenderer SpriteRenderer;
    Animator Animator;

    private void Awake()
    {
        if(TryGetComponent(out SpriteRenderer)) Animator = GetComponent<Animator>();
    }
    public void ChangeSpriteLevel(int level)
    {
        if (SpriteRenderer != null)
        {
            if (LevelsAnimatorControllers.Any()) Animator.runtimeAnimatorController = LevelsAnimatorControllers[level];
            else SpriteRenderer.sprite = LevelsSprites[level];

            return;
        }

        UIManager.SetImage(gameObject, LevelsSprites[level]);
    }
}
