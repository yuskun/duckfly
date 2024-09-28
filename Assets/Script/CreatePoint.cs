using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoint : MonoBehaviour
{
    public Transform highestPoint;
    public GameObject pointPrefab;

    public void createpoint()
    {

        float randomX = Random.Range(-2.5f, 2.5f);
        float randomY = Random.Range(2f, 4f);

        
        Vector2 newPosition = new Vector2(randomX, highestPoint.position.y + randomY);

        
        Instantiate(pointPrefab, newPosition, Quaternion.identity);

        
        highestPoint.position = newPosition;
    }
}
