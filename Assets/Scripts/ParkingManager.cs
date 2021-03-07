using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ParkingManager : MonoBehaviour
{
    [SerializeField] private CarController m_CarController;
    [SerializeField] private UIManager m_UIManager;
    [Tooltip("0 no check on the car's alignment, 1 the car have to be perfecly aligned with the slot.")]
    [Range(0, 1)] [SerializeField] private float m_RequiredAlignment;
    [SerializeField] private float m_MinimumSpeed;

    [SerializeField] private GameObject PerpendicularSlots;
    [SerializeField] private GameObject AngledSlots;
    [SerializeField] private GameObject ParallelSlots;

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
                    PerpendicularSlots.SetActive(false);
                    AngledSlots.SetActive(true);
                    m_UIManager.ResetParkingState(ParkingSlotType.Angled);
                    break;
                case ParkingSlotType.Angled:
                    AngledSlots.SetActive(false);
                    ParallelSlots.SetActive(true);
                    m_UIManager.ResetParkingState(ParkingSlotType.Parallel);
                    break;
                case ParkingSlotType.Parallel:
                    ParallelSlots.SetActive(false);
                    m_UIManager.DisplayEndGame();
                    break;
            }
        }
    }
}
