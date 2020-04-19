using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour 
{
	public float health = 100f;
	public float resetAfterDeathTime = 5f;
	public AudioClip deathClip;

	private FirstPersonController playerMovement;
	private LastPlayerSighting lastPlayerSighting;
	private float timer;
	private bool playerDead;

	void Awake()
	{
		playerMovement = GetComponent<FirstPersonController>();
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
	}

	void Update()
	{
		if(health <= 0f)
		{
			if(!playerDead)
			{
				PlayerDying();
			}
			else
			{
				PlayerDead();
				LevelReset();
			}
		}
	}

	void PlayerDying()
	{
		playerDead = true;
		AudioSource.PlayClipAtPoint(deathClip, transform.position);
	}
	void PlayerDead(){
		playerMovement.enabled = false;
		lastPlayerSighting.position = lastPlayerSighting.resetPosition;
	}

	void LevelReset()
	{

	}

	public void TakeDamage(float amount)
	{
		health -= amount;
	}

}
