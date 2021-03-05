using UnityEngine;

public class ParkingTriggerController : MonoBehaviour
{
    private Collider trigger;

    private void Awake()
    {
        trigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    float dot = Vector3.Dot(other.gameObject.transform.forward, transform.forward);
    //    float alignment = Mathf.Abs(dot);
    //    Debug.Log(alignment + "min: " + trigger.bounds.Contains(other.bounds.min) + " max: " + trigger.bounds.Contains(other.bounds.max));
    //}
}
