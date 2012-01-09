<?php
session_start();
$a=$_SESSION["id"];
if($_SESSION["logged"]!=1) 
{header("Location: login.php");}   
require_once "conn.php";
$id=$_GET['id'];
  if (isset($_POST['submit'])) {
    $id= $_POST['id'];
    $sql="INSERT INTO it_schedule(person, issue)VALUES('$a','$_POST[issue]')";
echo"INSERT INTO it_schedule(person, issue)VALUES('$a','$_POST[issue]')";
mysql_query($sql);
    }
  mysql_close($con);
?>
<<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title>Issue tracker</title>
<link rel="stylesheet" type="text/css" media="screen" href="style.php">
	</style>
</head>
<body>
<div id="container">
<?php require('header.php') ?>
<!-- main --><div id="page-wrap">
<form action="signissue.php" method="post"><fieldset><legend>Info:</legend>
<p> <label for="Username">
                   Titles:</label>
<select name="issue">
<?
 $con = mysql_connect("localhost","onehourb_tracker","tracker");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }

mysql_select_db("onehourb_itdb", $con);

$qry= "SELECT * FROM it_issue WHERE issue_id NOT
 IN (
 SELECT person
 FROM it_schedule
 WHERE person = $a
 )
 LIMIT 0 , 30";
$res = mysql_query($qry);
while ($game = mysql_fetch_row($res)) {
echo("
<option value='$game[0]'>$game[9]</option>
"); 
}
mysql_close($con);
?>
</select><br /></p>
<input type="hidden" id="id" name="id" value="<?php echo $id?>" />
<input type="submit" name="submit" value="Sign">
</fieldset></form>
</div><?php require('footer.php')?>
<!-- end footer -->
</div>
</body>
</html> 