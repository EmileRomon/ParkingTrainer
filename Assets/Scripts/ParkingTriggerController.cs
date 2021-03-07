using UnityEngine;

public enum ParkingSlotType
{
    Angled,
    Perpendicular,
    Parallel
}

[RequireComponent(typeof(Collider))]
public class ParkingTriggerController : MonoBehaviour
{
    [SerializeField] private ParkingSlotType m_ParkingSlotType = ParkingSlotType.Perpendicular;
    [SerializeField] private ParkingManager m_ParkingManager;
    private Collider m_Trigger;

    private void Awake()
    {
        m_Trigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_ParkingManager.ResetParkingState(m_ParkingSlotType);
    }

    private void OnTriggerStay(Collider other)
    {
        float dot = Vector3.Dot(other.gameObject.transform.forward, transform.forward);
        float alignment = Mathf.Abs(dot);
        m_ParkingManager.UpdateParkingState(alignment, m_Trigger.bounds.Contains(other.bounds.min) && m_Trigger.bounds.Contains(other.bounds.max), m_ParkingSlotType);
    }
}
