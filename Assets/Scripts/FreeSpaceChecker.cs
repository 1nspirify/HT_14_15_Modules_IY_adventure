using UnityEngine;

public class FreeSpaceChecker : MonoBehaviour
{
    public bool isOccupied {get; set;}

    private void Awake()
    {
        isOccupied = false;
    }

    private void Update()
    {
        if (gameObject.GetComponentInChildren<Item>())
        {
            isOccupied = true;
        }
        else
        {
            isOccupied = false;
        }
    }
}