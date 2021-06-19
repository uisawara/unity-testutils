using System.Collections;

namespace Tests
{
    public class UITest : IMmzkUnityDriver
    {
        private IMmzkUnityDriver _unity = new MmzkUnityDriver();

        public bool TakeScreenshotsAutomatically
        {
            get
            {
                return _unity.TakeScreenshotsAutomatically;
            }
            set
            {
                _unity.TakeScreenshotsAutomatically = value;
            }
        }

        public float DefaultTimeoutSeconds
        {
            get
            {
                return _unity.DefaultTimeoutSeconds;
            }
            set
            {
                _unity.DefaultTimeoutSeconds = value;
            }
        }

        public string ScreenshotBasePathName
        {
            get
            {
                return _unity.ScreenshotBasePathName;
            }
            set
            {
                _unity.ScreenshotBasePathName = value;
            }
        }

        public IEnumerator LoadScene(string sceneName)
        {
            yield return _unity.LoadScene(sceneName);
        }

        public IEnumerator Wait(string gameObjectName)
        {
            yield return _unity.Wait(gameObjectName, DefaultTimeoutSeconds);
        }

        public IEnumerator Wait(string gameObjectName, float timeoutSeconds)
        {
            yield return _unity.Wait(gameObjectName, timeoutSeconds);
        }

        public IEnumerator Click(string buttonObjectName)
        {
            yield return _unity.Click(buttonObjectName);
        }

        public IEnumerator Click(string buttonObjectName, float timeoutSeconds)
        {
            yield return _unity.Click(buttonObjectName, timeoutSeconds);
        }
        
        public IEnumerator TakeScreenshot(string imageFileName)
        {
            yield return _unity.TakeScreenshot(imageFileName);
        }

        public IEnumerator TakeScreenshot(string imageFileName, float timeoutSeconds)
        {
            yield return _unity.TakeScreenshot(imageFileName, timeoutSeconds);
        }
    }
}