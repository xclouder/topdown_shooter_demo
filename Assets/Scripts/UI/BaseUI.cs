using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour {

	void Awake()
	{
		OnCreateUI();
	}

	void OnDestroy()
	{
		OnDestroyUI();
	}

	public virtual void OnCreateUI()
	{
		Debug.Log("oncreate:" + this.GetType());
	}

	public virtual void Open()
	{
		this.gameObject.SetActive(true);
	}

	public virtual void Close()
	{
		this.gameObject.SetActive(false);
	}

	public virtual void OnDestroyUI()
	{

	}

}
