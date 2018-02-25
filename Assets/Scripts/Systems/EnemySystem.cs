using UnityEngine;
using System.Collections;

public class EnemySystem : MonoBehaviour, ISystem {

	public int enemyCount = 80;

	#region ISystem implementation

	public void Init ()
	{
		SpawnEnemy();
	}

	public void Reset ()
	{
		
	}

	public void LogicUpdate ()
	{
		
	}

	public void Release ()
	{
		
	}

	#endregion

	private float halfAreaWidth = 15f;
	private float halfAreaHeight = 15f;
	void SpawnEnemy()
	{
		var prefab = Resources.Load("Prefabs/Model/Enemy");
		var enemyContainerTr = GameObject.FindWithTag("EnemyContainer").transform;
		for (int i = 0; i < enemyCount; i++)
		{
			var enemyObj = GameObject.Instantiate(prefab) as GameObject;
			var enemyTr = enemyObj.transform;
			enemyTr.SetParent(enemyContainerTr);
			//enemyTr.localScale = Vector3.one * 0.5f;

			var randomX = Random.Range(-halfAreaWidth, halfAreaWidth);
			var randomZ = Random.Range(-halfAreaHeight, halfAreaHeight);

			enemyTr.position = new Vector3(randomX, 0.25f, randomZ);
		}
	}

}
