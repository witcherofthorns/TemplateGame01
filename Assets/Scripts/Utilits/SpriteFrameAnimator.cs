using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFrameAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private Sprite[] sprites;
    private byte frameCurrent;
    private byte frameMax;


    private void Start()
    {
        CreateAnimation();
    }

    private void CreateAnimation()
    {
        frameCurrent = 0;
        frameMax = (byte)sprites.Length;
    }

    public void SetAnimationFrames(Sprite[] spritesArray)
    {
        sprites = spritesArray;
        CreateAnimation();
    }

    public void NextAnimationFrame()
    {
        if((frameCurrent + 1) < frameMax) frameCurrent++;
        else frameCurrent = 0;
        render.sprite = sprites[frameCurrent];
    }
}
