using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	private int _maxHealth = 100;
	private int _currentHealth;
    public Text myText;

	void Start ()
    {
        _currentHealth = _maxHealth;
	}
	
	void Update ()
	{
        if (_currentHealth < 1)
        {
            //Dead
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
