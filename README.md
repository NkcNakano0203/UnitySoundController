# UnitySoundController
Unity環境でのBGM、SE管理を楽にするライブラリです。

# 使い方
## BGM
1. Projectフォルダで右クリックのコンテキストメニューから`BGMData`を作成します。

![image](https://github.com/user-attachments/assets/62c31ab6-720f-4649-912e-3c05e567660d)

2. 作成した`BGMData`にAudioClipや音量を設定します。

![image](https://github.com/user-attachments/assets/110b0072-d2ea-4fa9-aeac-6aeb620d430f)

3. BGMPlayerプレハブをHierarchyWindowに配置し、BGMDataをアタッチします

![image](https://github.com/user-attachments/assets/20d1779e-69b5-4a84-ac79-79001fc87d5b)

4. 鳴らしたいクラスで`MusicPlayer`をインスタンスを取得します。
サンプルコードではインスペクタからアタッチする形で取得しています。

![image](https://github.com/user-attachments/assets/4d5e3404-6297-4dbb-8abf-bcb513936e28)

5. `musicPlayer.Play()`の呼び出しをすることによって再生をすることができます。

## SE
1. Projectフォルダで右クリックのコンテキストメニューから`SEData`を作成します。

![image](https://github.com/user-attachments/assets/ea597ecd-2bd2-4636-bafd-3e06f365f936)

2. 作成した`SEData`にAudioClipや音量等を設定します。

![image](https://github.com/user-attachments/assets/68b598ae-417a-4b25-a710-95b3dfd30137)

3. 鳴らしたいクラスで`SoundEffectPlayer`と`SEData`を取得し、`soundEffectPlayer.PlayAsync()`メソッドで再生することができます。

![image](https://github.com/user-attachments/assets/9497f83d-1b9f-4f0b-ab00-ca79429d1505)
