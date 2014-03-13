MsTestListWriter
================


コマンドライン引数
-------

<table>
<tr>
  <th>引数</th>
  <th>説明</th>
</tr>
<tr>
  <td>/in:[ ファイルパス ]</td>
  <td>
    入力対象のファイルパスを指定します。 <br />
    入力例: /in:Lib.Test.dll
  </td>
</tr>
<tr>
  <td>/out:[ ファイルパス ]</td>
  <td>
    出力対象のファイルパスを指定します。<br />
    入力例: /out:data.xml
  </td>
</tr>
<tr>
  <td>/type:[ xml | csv ]</td>
  <td>
    出力対象のファイルフォーマットを指定します。<br />
    入力例: /type:xml
  </td>
</tr>
</table>


実行例
------- 

入力ファイル:Libs.Test.dll  
出力ファイル:data.xml   
ファイルタイプ:XML  

<code>MsTestListWriter.exe /in:Libs.Test.dll /out:data.xml /type:xml</code>
