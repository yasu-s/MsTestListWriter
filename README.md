MsTestListWriter
================


Command line arguments
-------

<table>
<tr>
  <th>argument</th>
  <th>description</th>
</tr>
<tr>
  <td>/in:[ file path ]</td>
  <td>
    specify a file path in which you want to enter. <br />
    example：/in:Lib.Test.dll
  </td>
</tr>
<tr>
  <td>/out:[ file path ]</td>
  <td>
    specify the file path of the output target. <br />
    example：/out:data.xml
  </td>
</tr>
<tr>
  <td>/type:[ xml | csv ]</td>
  <td>
    specify the file format of the output target. <br />
    example：/type:xml
  </td>
</tr>
</table>


Example
------- 

Input file：data.coverage  
Output file：data.xml   
File type:XML  

<code>MsTestListWriter.exe /in:Libs.Test.dll /out:data.xml /type:xml</code>
