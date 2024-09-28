using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject player;
    public GameObject GOUI1;
    public GameObject GOUI2;
    public TextMeshProUGUI Score;
      public TextMeshProUGUI FinalScore;

    
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        if(other.gameObject==player){
            GOUI1.SetActive(true);
            GOUI2.SetActive(true);
            FinalScore.text=Score.text;
        }

    }
}
