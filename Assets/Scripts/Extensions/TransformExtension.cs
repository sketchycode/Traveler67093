using UnityEngine;

public static class TransformExtensions {
    public static T GetChildByName<T>(this Transform thisTransform, string name) where T: Component {
        for(int i=0; i<thisTransform.childCount; i++) {
            var child = thisTransform.GetChild(i);
            if(child.name == name) { return child.GetComponent<T>(); }
        }
        return null;
    }
}
