<div id="main">
<div id="text">
<h1>Welcome</h1>
<?php
 require_once "conn.php";

$qry ="SELECT * FROM it_issue";
$res = mysql_query($qry );

function mysql_fetch_all($res) {
   while($row=mysql_fetch_array($res)) {
       $return[] = $row;
   }
   return $return;
}
$allmax = "40";
function create_table($dataArr) {
    echo "<div>";
    for($j = 0; $j < count($dataArr); $j++) {
        echo "<div  class=\"field\">".$dataArr[$j]."&nbsp&nbsp</div>";
    }
    echo "</div><br>";
}

$all = mysql_fetch_all($res);

for($i = 0; $i < count($all); $i++) {
    create_table($all[$i]);
}

mysql_close($con);
?>
</div>

</div>