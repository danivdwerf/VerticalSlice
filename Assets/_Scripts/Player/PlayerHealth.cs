using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	private int _maxHealth = 100;
	private int _currentHealth;
    public Text myText;
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
	}

    public void damage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }
		myText.text = _currentHealth.ToString();
    }
}
