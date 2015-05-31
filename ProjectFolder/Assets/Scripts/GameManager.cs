using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton<GameManager> {

    public void DestroyPlayer(Controller c)
    {
        CameraController.Instance.RemoveTarget(c);
        Destroy(c.gameObject);
    }
}
