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
<!-- main -->
<?php require('yourIssues.php')?>
<!-- end main -->
<!-- footer -->
<?php require('footer.php')?>
<!-- end footer -->
</div>
</body>
</html> 