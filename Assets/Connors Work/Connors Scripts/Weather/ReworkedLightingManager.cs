using UnityEngine;

[ExecuteAlways]
public class ReworkedLightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [Range(0, 24)] private float TimeOfDay;
    private float morning = 10.0f;
    private float evening = 18.1f;
    private float night = 23.0f;
    public float WaitTimeBeforeChangeLight;
    private float Timer = 0;

    private void Start()
    {
        TimeOfDay = morning;
    }

    private void Update()
    {
        if (Preset == null)
            return;

        //if the application is playing, change the the time of day between day, evening and night, 
        //at a speed set by the user. 
        if (Application.isPlaying)
        {   
            if(Timer >= WaitTimeBeforeChangeLight)
            {
                Timer = 0;
                if (TimeOfDay == morning)
                {
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                    TimeOfDay = evening;
                }
                else if (TimeOfDay == evening)
                {
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                    TimeOfDay = night;
                }
                else if(TimeOfDay == night)
                {
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                    TimeOfDay = morning;
                }
                    
            }
            else
            {
                Timer += Time.deltaTime;
            }
            
            
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }


    //updates the lighting to ve set to a new time
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

    //gets the time of day of the simple night and day cycle and returns it.
    public string GetSimpleCycle()
    {
        if(TimeOfDay == morning)
        {
            return "Morning";
        }
        else if(TimeOfDay == evening)
        {
            return "Evening";
        }
        else if(TimeOfDay == night)
        {
            return "Night";
        }
        else
        {
            return "Something went wrong in the reworked lighting";
        }
    }

}
