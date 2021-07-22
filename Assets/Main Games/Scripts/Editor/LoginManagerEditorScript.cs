using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// This will customer the inspect of LoginManager
[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditorScript : Editor
{

    public override void OnInspectorGUI()
    {

        
        //base.OnInspectorGUI();
        EditorGUILayout.HelpBox("This script is responsible for connecting to Photon servers.",MessageType.Info);

        LoginManager loginManager = (LoginManager)target;
        if (GUILayout.Button("Connect Anonymously"))
        {
            loginManager.ConnectedToPhotonServer();
        }

        //EditorGUILayout.HelpBox("This script is responsible for creating and joining rooms.", MessageType.Info);
        //if (GUILayout.Button("Join Random Room"))
        //{
        //    loginManager.JoinRandomRoom();
        //}
    }
}
