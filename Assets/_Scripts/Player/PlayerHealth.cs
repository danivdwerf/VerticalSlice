using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100;
    private float _currentHealth;
    public Text myText;
    public int healthText;
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
        myText.text = healthText.ToString();

        healthText = (int)Mathf.Round(_currentHealth);

        if (_currentHealth < 1)
        {
            _isDead = true;
        }
        if(_isDead == true)
        {
            Destroy(gameObject.GetComponent("Player Movement"));
        }
	}

    public void damage(float damageAmount)
    {

    }
}
