using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;

[CustomEditor(typeof(ItemConnectionPoint))]
public class ItemConnectionPoint_Editor : Editor {

    ItemConnectionPoint selfScript;

    public static Type type_HandleUtility;
    protected static System.Reflection.MethodInfo meth_IntersectRayMesh;

    //Type handleUtilityType;
    //Type[] types = { };

    void OnEnable() {
        selfScript = (ItemConnectionPoint)target;

        //handleUtilityType = Type.GetType("HandleUtility, Assembly_CSharp-Editor", false, false);

        Type[] editorTypes = typeof(Editor).Assembly.GetTypes();

        type_HandleUtility = editorTypes.FirstOrDefault<Type>(x => x.Name == "HandleUtility");
        meth_IntersectRayMesh = type_HandleUtility.GetMethod("IntersectRayMesh", (BindingFlags.Static | BindingFlags.NonPublic));
    }


    void OnSceneGUI() {
        



    }


    public bool IntersectRayMesh(Ray ray, Mesh mesh, Matrix4x4 matrix, out RaycastHit hit) {
        object[] parameters = new object[] { ray, mesh, matrix };

        bool result = (bool)meth_IntersectRayMesh.Invoke(null, parameters);

        hit = (RaycastHit)parameters[3];

        return result;
    }
}
