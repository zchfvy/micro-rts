using Entitas;
using Entitas.Unity;
using System;
using UnityEngine;

public static class ViewManager {

    public static Transform ViewContainer {
        get {
            if (_viewContainer == null) {
                _viewContainer = new GameObject("Views").transform;
            }
            return _viewContainer;
        }
    }

    private static Transform _viewContainer;

    public static GameObject CreateAndLinkView(IEntity entity, IContext context, string assetName) {
        var res = Resources.Load<GameObject>(assetName);
        GameObject go = null;
        try {
            go = UnityEngine.Object.Instantiate(res);
        } catch (Exception) {
            Debug.Log("Cannot instantiate " + res);
            throw;
        }

        if (go != null) {
            go.transform.SetParent(ViewContainer);
            go.Link(entity, context);
        }
        return go;
    }
}
