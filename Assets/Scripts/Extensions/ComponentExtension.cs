using UnityEngine;

public static class ComponentExtensions {
    public static T GetTheFuckingComponent<T>(this Component srcComp) where T: Component {
        var c = srcComp.GetComponent<T>();
        if(c != null) { return c; }

        c = srcComp.GetComponentInParent<T>();
        if(c != null) { return c; }

        c = srcComp.GetComponentInChildren<T>();
        return c;
    }
}
