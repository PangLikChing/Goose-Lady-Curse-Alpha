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
    public float fadeDeadZone = 0.1f;
    private bool isFadingIn;
    protected override void Awake()
    {
        base.Awake();
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
        if ((1-backGround.color.a) < fadeDeadZone && (1-image.color.a )< fadeDeadZone && (1-deathMsg.color.a )< fadeDeadZone)
        {
            backGround.color = Color.grey;
            image.color = Color.white;
            deathMsg.color = Color.white;
        }
    }

    private void FadeOut()
    {
        backGround.color = Color.Lerp(backGround.color, Color.clear, fadeSpeed * Time.deltaTime);
        image.color = Color.Lerp(image.color, Color.clear, fadeSpeed * Time.deltaTime);
        deathMsg.color = Color.Lerp(deathMsg.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (backGround.color.a < fadeDeadZone && image.color.a < fadeDeadZone && deathMsg.color.a < fadeDeadZone)
        {
            this.OnHideMenu();
        }
    }

    private void OnDisable()
    {
        backGround.color = Color.clear;
        image.color = Color.clear;
        deathMsg.color = Color.clear;
    }
}
