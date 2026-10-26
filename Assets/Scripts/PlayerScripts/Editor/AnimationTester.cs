using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
[CustomEditor(typeof(Player))]
public class AnimationTester : Editor
{
    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        base.OnInspectorGUI();
        if(GUILayout.Button("Try me"))
        {
            Debug.Log("Tried");
            serializedObject.targetObject.GetComponent<PlayerAnimatorScript>().PlayAnimation("Idle");//DOES NOT WORK

        }

    }
}
