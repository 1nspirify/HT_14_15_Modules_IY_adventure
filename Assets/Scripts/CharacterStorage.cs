using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class CharacterStorage : Character
{
    [SerializeField] private Transform _handDirection;
    [SerializeField] private FreeSpaceChecker _freeSpaceChecker;
    [SerializeField] private float _destroyTime;
    
    private string _logMessage = "ActionDone";
    private Item _currentItem;

    public void AddHealthPoints(int amount)
    {
        Health += amount;
    }

    public void AddSpeedPoints(float amount)
    {
        Speed += amount;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_freeSpaceChecker.isOccupied == false && other.gameObject.GetComponent<Item>() != null)
        {
            _currentItem = other.gameObject.GetComponent<Item>();
            _currentItem.transform.SetParent(_handDirection.transform);
        }
    }

    private void Update()
    {
        if (_currentItem != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _currentItem.UseItem(this);
              
                Debug.Log(_logMessage);
                
                Destroy(_currentItem.gameObject);
            }
            
            Destroy(_currentItem.gameObject, _destroyTime);
        }
    }
}