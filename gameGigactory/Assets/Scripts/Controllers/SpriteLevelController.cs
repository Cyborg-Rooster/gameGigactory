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
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }
    public void ChangeSpriteLevel(int level)
    {
        if(LevelsAnimatorControllers.Any())
        {
            Animator.runtimeAnimatorController = LevelsAnimatorControllers[level];
            return;
        }

        SpriteRenderer.sprite = LevelsSprites[level];
    }
}
