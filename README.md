# unity-testutils

* UnityでUIテストを作りやすくするためのPackage

## Key features

* UI要素のWait, ClickなどUIテストをするうえでよく使う操作
* スクリーンショットの記録
* 各種操作時の自動スクリーンショット記録

## Installation

manifest.jsonに以下を追記します

```
"work.mmzk.testutils":"https://github.com/uisawara/unity-testutils.git#upm"
```

## Overview

### 準備

* Testsディレクトリ+Assembly Definitionを作成する。(Project Window / menu Create > Testing > Tests Assembly Folder")
* 作成されたTests.asmdefのinspectorを開きAssembly Definition ReferencesにMmzkTestUtilsを追加する。

### テストの実装

* 先ほど作成したTestsディレクトリにC# Test Scriptを作成する。(Project Window / menu Create > Testing > C# Test Script)
* スクリプトを編集、テストを記述する。

```cs
// 1. UITestを継承する
public class BasicScenarioTest : UITest
{
    [SetUp]
    public void Setup()
    {
        // 2. スクリーンショットの保存先パス名を設定する。
        ScreenshotBasePathName = "reports/screenshots/" + GetType().Name;
        // 3. 操作の都度、自動でスクリーンショット保存する設定を有効にする。
        TakeScreenshotsAutomatically = true;
    }

    // テストコード
    [UnityTest]
    public IEnumerator BasicScenarioTestPasses()
    {
        // シーンを読み込み
        yield return LoadScene("SampleScene");
        // 引数でしたゲームオブジェクト名のボタンをクリック
        yield return Click("$EnterButton");
        // 引数で指定したオブジェクトが出現するまで待つ
        yield return Wait("$Sample");
    }
}
```
