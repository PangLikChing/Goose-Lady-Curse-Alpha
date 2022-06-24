using UnityEngine;

[ExecuteAlways]
public class OriginalLightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;
    public bool DemoRun = false;
    public float WaitTimeBeforeChangeLight;
    private float Timer = 0;
    public float AmountToChangeLightBy;

    private void Update()
    {
        if (Preset == null)
            return;

        //if the application is running, change the time of day slowly based on how the user wants it to. either by 
        //a default demo run, or by specific settings.
        if (Application.isPlaying)
        {
            if(DemoRun == true)
            {
                //(Replace with a reference to the game time)
                TimeOfDay += Time.deltaTime;
                TimeOfDay %= 24; //Modulus to ensure always between 0-24
                UpdateLighting(TimeOfDay / 24f);
            }
            else
            {
                if(Timer >= WaitTimeBeforeChangeLight)
                {
                    Timer = 0;
                    TimeOfDay += AmountToChangeLightBy;
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                }
                else
                {
                    Timer += Time.deltaTime;
                }
            }
            
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    //Change the time of day of the lighting
    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }



    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

    //Get the time of day based on where the sun is in the sky.
    public string GetAdvancedCycle()
    {
        if (TimeOfDay >= 6 && TimeOfDay <= 17)
        {
            return "Morning";
        }
        else if (TimeOfDay >= 17 && TimeOfDay <= 19)
        {
            return "Evening";
        }
        else
        {
            return "Night";
        }
    }

}
