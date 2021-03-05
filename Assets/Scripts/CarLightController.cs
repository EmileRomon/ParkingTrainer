using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarLightController : MonoBehaviour
{
    [SerializeField] private CarController car;
    [SerializeField] private Renderer brakeLights;
    [SerializeField] private Material brakeLightsOn;
    [SerializeField] private Material brakeLightsOff;
    [SerializeField] private GameObject tailLights;

    void Update()
    {
        if (car.BrakeInput > 0f)
        {
            brakeLights.material = brakeLightsOn;
            tailLights.SetActive(true);
        }
        else
        {
            brakeLights.material = brakeLightsOff;
            tailLights.SetActive(false);
        }
    }
}
