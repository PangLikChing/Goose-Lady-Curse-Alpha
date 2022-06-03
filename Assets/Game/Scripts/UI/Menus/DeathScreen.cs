using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathScreen : Menu
{
    public TMP_Text deathMsg;
    public Image image;
    public Image backGround;
    public float fadeSpeed;

    private bool isFadingIn;
    private Color bgColorTransparent = Color.grey;
    private Color imageColorTransparent = Color.white;
    private Color deathMsgTransparent = Color.white;
    protected override void Awake()
    {
        base.Awake();
        bgColorTransparent.a = 0;
        backGround.color = bgColorTransparent; 
        imageColorTransparent.a = 0;
        image.color = imageColorTransparent;
        deathMsgTransparent.a = 0;
        deathMsg.color = deathMsgTransparent;
    }

    private void Update()
    {
        if (isFadingIn)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
        if (IsTransparent() && !isFadingIn)
        {
            this.OnHideMenu();
        }
    }

    public void ToggleFade()
    {
        isFadingIn = !isFadingIn;
    }

    private void FadeIn()
    {
        backGround.color = Color.Lerp(backGround.color, Color.grey, fadeSpeed * Time.deltaTime);
        image.color = Color.Lerp(image.color, Color.white, fadeSpeed * Time.deltaTime);
        deathMsg.color = Color.Lerp(deathMsg.color, Color.white, fadeSpeed * Time.deltaTime);
    }

    private void FadeOut()
    {
        backGround.color = Color.Lerp(backGround.color, bgColorTransparent, fadeSpeed * Time.deltaTime);
        image.color = Color.Lerp(image.color, imageColorTransparent, fadeSpeed * Time.deltaTime);
        deathMsg.color = Color.Lerp(deathMsg.color, deathMsgTransparent, fadeSpeed * Time.deltaTime);
    }

    private bool IsTransparent()
    {
        if (backGround.color == bgColorTransparent && image.color == imageColorTransparent && deathMsg.color == deathMsgTransparent)
        {
            return true;
        }
        return false;
    }

    private void OnDisable()
    {
        backGround.color = bgColorTransparent;
        image.color = imageColorTransparent;
        deathMsg.color = deathMsgTransparent;
    }
}
