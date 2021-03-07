using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_AlignmentIndicator;
    [SerializeField] private GameObject m_PositionIndicator;
    [SerializeField] private GameObject m_CarStoppedIndicator;
    [SerializeField] private GameObject m_ParkingStateContainer;

    [SerializeField] private TextMeshProUGUI m_ParkingTypeText;
    [SerializeField] private string m_ParkingTypeMessage = "{0} parking";

    [SerializeField] private TextMeshProUGUI m_CollisionCountText;
    [SerializeField] private string m_CollisionCountMessage = "Collision count: {0}";

    [SerializeField] private GameObject m_EndGame;
    [SerializeField] private TextMeshProUGUI m_CollisionCountP1;
    [SerializeField] private string m_CollisionCountP1Message = "Perpendicular parking: {0} hits";
    [SerializeField] private TextMeshProUGUI m_CollisionCountP2;
    [SerializeField] private string m_CollisionCountP2Message = "Angled parking: {0} hits";
    [SerializeField] private TextMeshProUGUI m_CollisionCountP3;
    [SerializeField] private string m_CollisionCountP3Message = "Parallel parking: {0} hits";

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

    public void DisplayEndGame(int[] collisionCounts)
    {
        m_EndGame.SetActive(true);
        m_CollisionCountP1.text = string.Format(m_CollisionCountP1Message, collisionCounts[0]);
        m_CollisionCountP2.text = string.Format(m_CollisionCountP2Message, collisionCounts[1]);
        m_CollisionCountP3.text = string.Format(m_CollisionCountP3Message, collisionCounts[2]);
    }

    public void ResetParkingState(ParkingSlotType parkingType, bool showContainer = false)
    {
        if (showContainer)
        {
            m_ParkingStateContainer.SetActive(true);
        }
        else
        {
            SetCollisionCount(0);
        }
        m_ParkingTypeText.text = string.Format(m_ParkingTypeMessage, parkingType.ToString());
        m_AlignmentIndicator.SetActive(false);
        m_PositionIndicator.SetActive(false);
        m_CarStoppedIndicator.SetActive(false);
    }

    public void SetCollisionCount(int count)
    {
        m_CollisionCountText.text = string.Format(m_CollisionCountMessage, count);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
