using UnityEngine;
//using System.Collections;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	#region Singleton

	private static T sm_instance;

	public static T Instance
	{	
		get
		{
			if(sm_instance == null)
				sm_instance = (T)MonoBehaviour.FindObjectOfType(typeof(T));

			return sm_instance;
		}
	}

	#endregion

	#region Persistant

	public static void MakePersistant(T t)
	{
		if(sm_instance == null)
		{
			// If this is the first instance, set Singleton
			sm_instance = t;
			DontDestroyOnLoad(sm_instance);
		}
		else
		{
			// If a Singleton already exists destroy any other references in the scene
			if(t != sm_instance)
				Destroy(t.gameObject);
		}
	}

	#endregion
}
