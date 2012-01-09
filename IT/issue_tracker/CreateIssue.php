<?php
session_start();
$a=$_SESSION["id"];
if($_SESSION["logged"]!=1) 
{header("Location: login.php");}
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
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
<div id="main">
<div id="text">
<h1>Create issue</h1>					
<?php
$quote = $_POST["quote"];
$issue = $_POST["issue"];
$title= $_POST["title"];
$dt1=date("Y-m-d"); 
if (!isset($_POST['submit'])) {
?>
<form method="post" action="<?php echo $PHP_SELF;?>">
<b>Input title of Issue:</b>
<input type="text" name="title" /><br />
<b>Select a Type of Issue:</b>
<select name="issue">
<?
define('SQL_HOST','localhost');
define('SQL_USER','onehourb_tracker');
define('SQL_PASS','tracker');
define('SQL_DB','onehourb_itdb');

$con = mysql_connect(SQL_HOST,SQL_USER,SQL_PASS) or
	die('Couldn\'t connect to the DB:' . mysql_error());
mysql_select_db(SQL_DB,$con) or
	die ('Couldn\'t select the DB:' . mysql_error());

$qry ="SELECT * FROM it_type";
$res = mysql_query($qry );

while ($game = mysql_fetch_row($res)) {
echo("
<option value='$game[0]'>$game[1]</option>
"); 
}
mysql_close($con);
?>
</select><br />
<b>Enter your description:</b>
<textarea rows="5" cols="20" name="quote" wrap="physical"></textarea>
<input type="submit" value="submit" name="submit"/>
</form>
<?
} else {
define('SQL_HOST','localhost');
define('SQL_USER','onehourb_tracker');
define('SQL_PASS','tracker');
define('SQL_DB','onehourb_itdb');

$con = mysql_connect(SQL_HOST,SQL_USER,SQL_PASS) or
	die('Couldn\'t connect to the DB:' . mysql_error());
mysql_select_db(SQL_DB,$con) or
	die ('Couldn\'t select the DB:' . mysql_error());

mysql_query("INSERT INTO it_issue (type, status, issue_description,issue_user_created,issue_reopened,issue_time_created,issue_title )
VALUES ('$issue', '1', '$quote', '$a', '0',CURDATE(),'$title')");
mysql_close($con);
echo"You created a new issue";
}
?> 
</div>
</div>
<?php require('footer.php')?>
<!-- end footer -->
</body>
</html> 