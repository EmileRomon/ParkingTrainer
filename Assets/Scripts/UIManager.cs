using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_AlignmentIndicator;
    [SerializeField] private GameObject m_PositionIndicator;
    [SerializeField] private GameObject m_CarStoppedIndicator;
    [SerializeField] private GameObject m_ParkingStateContainer;
    [SerializeField] private TextMeshProUGUI m_ParkingTypeText;
    [SerializeField] private string m_ParkingTypeMessage = "{0} parking";

    private void Start()
    {
        ResetParkingState(ParkingSlotType.Perpendicular);
    }

    public void UpdateParkingState(bool isAligned, bool inside, bool isStopped)
    {
        m_AlignmentIndicator.SetActive(isAligned);
        m_PositionIndicator.SetActive(inside);
        m_CarStoppedIndicator.SetActive(isStopped);
    }

    public void DisplayEndGame()
    {
        Debug.Log("Endgame");
    }

    public void ResetParkingState(ParkingSlotType parkingType, bool showContainer = false)
    {
        m_ParkingStateContainer.SetActive(showContainer);
        m_ParkingTypeText.text = string.Format(m_ParkingTypeMessage, parkingType.ToString());
        m_AlignmentIndicator.SetActive(false);
        m_PositionIndicator.SetActive(false);
        m_CarStoppedIndicator.SetActive(false);

    }
}
