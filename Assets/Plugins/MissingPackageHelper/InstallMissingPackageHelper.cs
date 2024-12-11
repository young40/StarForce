using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

#if UNITY_2022_1_OR_NEWER
namespace UnityGameFramework.Editor.MissingPackage
{
    public class InstallMissingPackageHelper
    {
        private static AddRequest request;

        static InstallMissingPackageHelper()
        {
            request = Client.Add("com.unity.ugui");

            EditorApplication.update += Update;
        }

        private static void Update()
        {
            if (request.IsCompleted)
            {
                if (request.Status == StatusCode.Success)
                {
                    Debug.Log("Add missing ugui package.");
                }
                else
                {
                    throw new Exception("Add missing ugui package failed.");
                }
                
                EditorApplication.update -= Update;
            }
        }
    }
}
#endif