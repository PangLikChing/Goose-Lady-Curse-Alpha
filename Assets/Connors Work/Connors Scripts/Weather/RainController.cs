using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    //variable declaration
    public GameObject Rain;
    public float TimeBetweenChecks;
    public float ChanceOfRain;
    public float DurationOfRain;
    private float timer = 0;
    private float timer2 = 0;
    private float randomNum;

    // Update is called once per frame
    void Update()
    {
        //regulates how often the chance for it to rain is checked, as well as how big the chance is.
        //Chance of rain and time between checks are both set by the user in the unity viewer.
        //if the chance is true, make it rain for a set period of time. 
        if(timer >= TimeBetweenChecks && Rain.active == false)
        {
            randomNum = Random.Range(1, ChanceOfRain);
            randomNum = randomNum + 1;
            if (randomNum >= ChanceOfRain)
            {
                timer = 0;
                Rain.SetActive(true);
                Rain.GetComponent<ParticleSystem>().Play();


            }
            else
            {
                timer = 0;
            }
        }
        else if(timer < TimeBetweenChecks && Rain.active == false)
        {
            timer += Time.deltaTime;
        }
        else if(Rain.active == true)
        {
            if (timer2 < DurationOfRain)
            {
                timer2 += Time.deltaTime;
            }
            else
            {
                timer2 = 0;
                StartCoroutine(TurnRainOff());
                StartCoroutine(FadeOut(Rain.GetComponent<AudioSource>(), 1));
            }
        }
    }
    
    //turns the rain off
    IEnumerator TurnRainOff()
    {
        Rain.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(1);
        Rain.SetActive(false);
    }

    //slowly fades the rain sound off as the rain slowly stops
    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
