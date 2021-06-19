using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public static class TestUtil
    {
        public static IEnumerator TakeScreenshot(string imageFileName, float timeoutSeconds)
        {
            Debug.Log($"[TakeScreenshot] {imageFileName}");

            var imageFilePath = Path.GetDirectoryName(imageFileName);
            if (!Directory.Exists(imageFilePath))
            {
                Directory.CreateDirectory(imageFilePath);
            }
            
            if (File.Exists(imageFileName))
            {
                File.Delete(imageFileName);
            }
            
            ScreenCapture.CaptureScreenshot(imageFileName);

            var startTime = Time.time;
            float timespan = 0f;
            while (File.Exists(imageFileName) == false && (timespan = Time.time - startTime) < timeoutSeconds)
            {
                yield return null;
            }
            
            if (timespan >= timeoutSeconds)
            {
                throw new TimeoutException($"TakeScreenshot {imageFileName} timedout");
            }
        }

        public static IEnumerator Wait(string gameObjectName, float timeoutSeconds)
        {
            Debug.Log($"[Wait] {gameObjectName}");
            var startTime = Time.time;
            float timespan = 0f;
            yield return new WaitWhile(() => GameObject.Find(gameObjectName) == null && (timespan = Time.time - startTime) < timeoutSeconds);
            if (timespan >= timeoutSeconds)
            {
                throw new TimeoutException($"Wait {gameObjectName} timedout");
            }
        }

        public static IEnumerator Click(string buttonObjectName, float timeoutSeconds)
        {
            Debug.Log($"[Click] {buttonObjectName}");
            GameObject gameObject = null;
            var startTime = Time.time;
            float timespan = 0f;
            yield return new WaitWhile(() => (gameObject = GameObject.Find(buttonObjectName)) == null && (timespan = Time.time - startTime) < timeoutSeconds);
            if (timespan >= timeoutSeconds)
            {
                throw new TimeoutException($"Click {buttonObjectName} timedout");
            }
            var button = gameObject.GetComponent<Button>();
            if (button == null)
            {
                throw new NullReferenceException($"{buttonObjectName} has not Button component");
            }
            
            button.onClick.Invoke();
        }
    }
}
