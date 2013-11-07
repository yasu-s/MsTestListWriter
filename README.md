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
    example�F/in:Lib.Test.dll
  </td>
</tr>
<tr>
  <td>/out:[ file path ]</td>
  <td>
    specify the file path of the output target. <br />
    example�F/out:data.xml
  </td>
</tr>
<tr>
  <td>/type:[ xml | csv ]</td>
  <td>
    specify the file format of the output target. <br />
    example�F/type:xml
  </td>
</tr>
</table>


Example
------- 

Input file�Fdata.coverage  
Output file�Fdata.xml   
File type:XML  

<code>MsTestListWriter.exe /in:Libs.Test.dll /out:data.xml /type:xml</code>
