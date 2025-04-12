using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private Transform _handDirection;
    [SerializeField] private FreeSpaceChecker _freeSpaceChecker;
    [SerializeField] private float _destroyTime;
    
    private string _logMessage = "ActionDone";
    private Item _currentItem;
    
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
                _currentItem.Use(this);
              
                Debug.Log(_logMessage);
                
                Destroy(_currentItem.gameObject);
            }
            
            Destroy(_currentItem.gameObject, _destroyTime);
        }
    }
}