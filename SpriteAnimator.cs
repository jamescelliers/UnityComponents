using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour
{

    public enum PlayMode { Loop, RubberBand, PlayOnce }
    public PlayMode Mode = PlayMode.Loop;
    public Sprite[] SpriteList;
    private SpriteRenderer sr;
    private int currentIndex = 0;
    public float playRate = 1.0f;
    private float timer = 0.0f;
    public bool IsPlaying { get; private set; }
    private bool inReverse = false;
    public bool PlayOnStart = false;
    public int DefaultIndex = 0;

    void Start()
    {
        if (GetComponent<SpriteRenderer>())
        {
            sr = GetComponent<SpriteRenderer>();
        }
        else
        {
            sr = gameObject.AddComponent<SpriteRenderer>();
        }
        if (SpriteList.Length > 0)
        {
            sr.sprite = SpriteList[DefaultIndex];
        }
        if (PlayOnStart)
        {
            Play();
        }
    }

    void Update()
    {
        if (IsPlaying)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            if (timer <= 0)
            {

                if (currentIndex == (SpriteList.Length - 1))
                {
                    if (Mode != PlayMode.RubberBand)
                    {
                        currentIndex = 0;
                        if (Mode == PlayMode.PlayOnce)
                        {
                            Stop();
                        }
                    }
                    else
                    {
                        inReverse = true;
                        currentIndex = SpriteList.Length - 2;
                    }
                }
                else
                if (currentIndex == 0 && inReverse == true)
                {
                    currentIndex = 1;
                    inReverse = false;
                }
                else
                {
                    if (!inReverse)
                        currentIndex++;
                    else
                        currentIndex--;
                }

                sr.sprite = SpriteList[currentIndex];
                timer = playRate;
            }
        }
    }

    public void SetSprites(Sprite[] sprites, int _defaultIndex)
    {
        SpriteList = sprites;
        DefaultIndex = _defaultIndex;
        sr.sprite = SpriteList[DefaultIndex];
    }

    public void Play()
    {
        IsPlaying = true;
    }

    public void Stop()
    {
        IsPlaying = false;
        sr.sprite = SpriteList[DefaultIndex];

    }
}