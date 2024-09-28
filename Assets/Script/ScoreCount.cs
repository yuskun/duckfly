using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public GameObject player;
    public float InitLocation=-3.75f;
    public TextMeshProUGUI Score;
    private float highestLocation=-3.75f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(highestLocation<player.transform.position.y){
        highestLocation=player.transform.position.y;

        Score.text=(Mathf.Abs(Mathf.FloorToInt(highestLocation - InitLocation))*10).ToString();
      }
          
        
    }
}
