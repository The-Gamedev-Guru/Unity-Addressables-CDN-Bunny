// Copyright 2019 The Gamedev Guru (http://thegamedev.guru)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#pragma warning disable 4014
using System;
using System.IO;
using System.Threading.Tasks;
using BunnyCDN.Net.Storage;
using UnityEditor;
using UnityEngine;

namespace TheGamedevGuru
{
    /// <summary>
    /// This script will help you uploading your Unity Addressables content to your BunnyCDN Storage Zone.
    /// Questions? E-mail me at ruben@thegamedev.guru
    /// </summary>
    public class UploadToBunnyCDN : EditorWindow
    {
        private string _remoteBuildPath;
        private string _storageZoneName;
        private string _apiAccessKey;
        
        [MenuItem("GamedevGuru/Addressables BunnyCDN Uploader")]
        static void Init()
        {
            var window = (UploadToBunnyCDN)EditorWindow.GetWindow(typeof(UploadToBunnyCDN), false, "Addressables BunnyCDN Uploader - TheGamedevGuru");
            window._remoteBuildPath = EditorPrefs.GetString("UploadToBunnyCDN_remoteBuildPath", "ServerData/");
            window._storageZoneName = EditorPrefs.GetString("UploadToBunnyCDN_storageZoneName", "** SET STORAGE ZONE NAME **");
            window._apiAccessKey = EditorPrefs.GetString("UploadToBunnyCDN_apiAccessKey", "** SET SECRET KEY **");
            window.Show();
        }
        
        void OnGUI()
        {
            GUILayout.Label("Base Settings", EditorStyles.boldLabel);
            _remoteBuildPath = EditorGUILayout.TextField("RemoteBuildPath", _remoteBuildPath);
            _storageZoneName = EditorGUILayout.TextField("Storage Zone Name", _storageZoneName);
            _apiAccessKey = EditorGUILayout.TextField("API Access Key", _apiAccessKey);
            if (GUILayout.Button("Upload content"))
            {
                if (!_remoteBuildPath.EndsWith("/")) _remoteBuildPath += "/";
                EditorPrefs.SetString("UploadToBunnyCDN_remoteBuildPath", _remoteBuildPath);
                EditorPrefs.SetString("UploadToBunnyCDN_storageZoneName", _storageZoneName);
                EditorPrefs.SetString("UploadToBunnyCDN_apiAccessKey", _apiAccessKey);
                InitiateTask();
            }

            if (GUILayout.Button("Help me setting up the keys!"))
            {
                Application.OpenURL("https://bunnycdn.com/dashboard/storagezones");
            }
            if (GUILayout.Button("I still need help!"))
            {
                EditorUtility.DisplayDialog("Help", "Ok, ok, send me an e-mail to ruben@thegamedev.guru and I'll see what I can do. Otherwise, post a comment in the blog article", "Ok thanks");
            }
        }
        
        async Task InitiateTask()   {
            await UploadAsync(_storageZoneName, _apiAccessKey, _remoteBuildPath);
        }
        
        private static async Task UploadAsync(string storageZoneName, string apiAccessKey, string path)
        {
            try
            {
                Debug.Log("Starting upload...");
                var bunnyCdnStorage = new BunnyCDNStorage(storageZoneName, apiAccessKey);
                foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
                {
                    var target = $"/{storageZoneName}/{file.Replace(path, "")}";
                    Debug.Log($"Uploading {file} to {target}");
                    await bunnyCdnStorage.UploadAsync(file, target);
                }
                Debug.Log("Upload completed");
            }
            catch (Exception e)
            {
                Debug.LogError("UploadToBunnyCDN Exception: " + e.Message);
            }
        }
 
    }
}
#pragma warning restore 4014
