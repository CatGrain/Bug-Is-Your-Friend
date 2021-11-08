using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text PlayerPoints;  
    public Text AiPoints;

    private void Start()
    {
        GameEvents.current.addAiPoints += AddAiPoints;
        GameEvents.current.addPlayerPoints += AddPlayerPoints;
    }

    void AddPlayerPoints()
    {
        int playerPoints = int.Parse(PlayerPoints.text);
        playerPoints++;
        PlayerPoints.text = playerPoints.ToString();
    }

    void AddAiPoints()
    {
        int aiPoints = int.Parse(AiPoints.text);
        aiPoints++;
        AiPoints.text = aiPoints.ToString();
    }


}
