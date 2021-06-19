using System.Collections;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;

namespace Tests
{
    public interface IMmzkUnityDriver
    {
        bool TakeScreenshotsAutomatically { get; set; }
        float DefaultTimeoutSeconds { get; set; }
        string ScreenshotBasePathName { get; set; }
        IEnumerator LoadScene(string sceneName);
        IEnumerator Wait(string gameObjectName);
        IEnumerator Wait(string gameObjectName, float timeoutSeconds);
        IEnumerator Click(string buttonObjectName);
        IEnumerator Click(string buttonObjectName, float timeoutSeconds);
        IEnumerator TakeScreenshot(string imageFileName);
        IEnumerator TakeScreenshot(string imageFileName, float timeoutSeconds);
    }
    
    public class MmzkUnityDriver : IMmzkUnityDriver
    {
        public bool TakeScreenshotsAutomatically { get; set; } = false;
        public float DefaultTimeoutSeconds { get; set; } = 5f;

        public string ScreenshotBasePathName { get; set; } = "results/screenshots/";

        private int _counter;

        public IEnumerator LoadScene(string sceneName)
        {
            EditorSceneManager.LoadScene(sceneName);
            yield return null;
        }

        public IEnumerator Wait(string gameObjectName)
        {
            if (TakeScreenshotsAutomatically)
            {
                yield return TakeScreenshot($"{ScreenshotBasePathName}{_counter++}.png", DefaultTimeoutSeconds);
            }
            yield return TestUtil.Wait(gameObjectName, DefaultTimeoutSeconds);
        }
        
        public IEnumerator Wait(string gameObjectName, float timeoutSeconds)
        {
            if (TakeScreenshotsAutomatically)
            {
                yield return TakeScreenshot($"{ScreenshotBasePathName}{_counter++}.png", timeoutSeconds);
            }
            yield return TestUtil.Wait(gameObjectName, timeoutSeconds);
        }

        public IEnumerator Click(string buttonObjectName)
        {
            if (TakeScreenshotsAutomatically)
            {
                yield return TakeScreenshot(DefaultTimeoutSeconds);
            }
            yield return TestUtil.Click(buttonObjectName, DefaultTimeoutSeconds);
        }

        public IEnumerator Click(string buttonObjectName, float timeoutSeconds)
        {
            if (TakeScreenshotsAutomatically)
            {
                yield return TakeScreenshot(timeoutSeconds);
            }
            yield return TestUtil.Click(buttonObjectName, timeoutSeconds);
        }
        
        public IEnumerator TakeScreenshot(string imageFileName)
        {
            yield return TakeScreenshot(imageFileName, DefaultTimeoutSeconds);
        }

        public IEnumerator TakeScreenshot(string imageFileName, float timeoutSeconds)
        {
            yield return TestUtil.TakeScreenshot(imageFileName, timeoutSeconds);
        }

        private IEnumerator TakeScreenshot(float timeoutSeconds)
        {
            return TakeScreenshot($"{ScreenshotBasePathName}{_counter++}.png", timeoutSeconds);
        }
    }
}