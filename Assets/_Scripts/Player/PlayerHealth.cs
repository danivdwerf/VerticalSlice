using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100;
    private float _currentHealth; 
    public float SetHealth
    {
        set
        {
            _currentHealth -= value;
            Debug.Log(_currentHealth);
        }
    }
    private bool _isDead;

	void Start ()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
	}
	
	void Update ()
    {
        if (_currentHealth < 1)
        {
            _isDead = true;
        }
        if(_isDead == true)
        {
            Destroy(gameObject.GetComponent("Player Movement"));
        }
        //Debug.Log(_currentHealth);
	}
}
