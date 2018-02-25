using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SystemMgr : MonoBehaviour {

	private Dictionary<System.Type, ISystem> m_sysDict;
	private static SystemMgr m_ins;

	public static SystemMgr Instance
	{
		get 
		{
			return m_ins;
		}
	}

	void Start () {
		m_ins = this;
		m_sysDict = new Dictionary<System.Type, ISystem>();

		var sysArr = GetComponentsInChildren<ISystem>();

		foreach (var sys in sysArr)
		{
			m_sysDict.Add(sys.GetType(), sys);
		}

		foreach (var sys in sysArr)
		{
			sys.Init();
		}
	}

	public T GetSystem<T>() where T : class, ISystem
	{
		ISystem sys = null;

		if (m_sysDict.TryGetValue(typeof(T), out sys))
		{
			return (T)sys;
		}
		else
		{
			Debug.LogError("cannot find a sys with type:" + typeof(T));
			return null;
		}
	}

	void Update()
	{
		if (m_isPaused)
		{
			return;
		}

		foreach (var kvp in m_sysDict)
		{
			kvp.Value.LogicUpdate();
		}
	}

	private bool m_isPaused = false;
	public bool IsPaused
	{
		get{
			return m_isPaused;
		}
	}
	public void PauseUpdate()
	{
		m_isPaused = true;
	}

	public void ResumeUpdate()
	{
		m_isPaused = false;
	}

	void OnDestroy()
	{
		foreach (var kvp in m_sysDict)
		{
			kvp.Value.Release();
		}
	}

}
