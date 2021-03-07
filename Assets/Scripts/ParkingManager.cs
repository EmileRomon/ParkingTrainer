using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ParkingManager : MonoBehaviour
{
    [SerializeField] private CarController m_CarController;
    [SerializeField] private UIManager m_UIManager;
    [Tooltip("0 no check on the car's alignment, 1 the car have to be perfecly aligned with the slot.")]
    [Range(0, 1)] [SerializeField] private float m_RequiredAlignment;
    [SerializeField] private float m_MinimumSpeed;

    [SerializeField] private GameObject m_PerpendicularSlots;
    [SerializeField] private GameObject m_AngledSlots;
    [SerializeField] private GameObject m_ParallelSlots;

    private int[] m_CollisionCounts = new int[3];
    private int m_CollisonCountIndex = 0;

    public void AddCollision()
    {
        m_UIManager.SetCollisionCount(++m_CollisionCounts[m_CollisonCountIndex]);
    }

    public void ResetParkingState(ParkingSlotType parkingType)
    {
        m_UIManager.ResetParkingState(parkingType, true);
    }

    public void UpdateParkingState(float alignment, bool insideTrigger, ParkingSlotType parkingType)
    {
        bool isAligned = alignment >= m_RequiredAlignment;
        bool isStopped = m_CarController.CurrentSpeed <= m_MinimumSpeed;
        m_UIManager.UpdateParkingState(isAligned, insideTrigger, isStopped);
        if (isAligned && insideTrigger && isStopped)
        {
            switch (parkingType)
            {
                case ParkingSlotType.Perpendicular:
                    m_PerpendicularSlots.SetActive(false);
                    m_AngledSlots.SetActive(true);
                    m_UIManager.ResetParkingState(ParkingSlotType.Angled);
                    break;
                case ParkingSlotType.Angled:
                    m_AngledSlots.SetActive(false);
                    m_ParallelSlots.SetActive(true);
                    m_UIManager.ResetParkingState(ParkingSlotType.Parallel);
                    break;
                case ParkingSlotType.Parallel:
                    m_ParallelSlots.SetActive(false);
                    m_UIManager.DisplayEndGame(m_CollisionCounts);
                    break;
            }
            m_CollisonCountIndex++;
        }
    }
}
