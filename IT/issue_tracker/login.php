<?php
session_start();
$_SESSION['logged'] = 0;
if (isset($_POST['submit'])) {
$con = mysql_connect("localhost","onehourb_tracker","tracker");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }
mysql_select_db("onehourb_itdb", $con);
$qry ="SELECT * FROM it_people WHERE username='" . $_POST['username'] . "' AND password=sha1('" . $_POST['password'] . "')";
$res = mysql_query($qry );
$row = mysql_fetch_array($res);
if (mysql_num_rows($res ) > 0) {
$_SESSION['logged'] = 1;
$a=$row['person_id'];
$_SESSION['id'] =$a ;
header("Location: index.php");
mysql_close($con);
} else {
?>
<html>
<head>
<title>Login</title>
<link rel="stylesheet" type="text/css" media="screen" href="style.php">
</head>
<body>
<div id="page-wrap">
<p>
Invalid Username and/or Password<br><br>
<form action="login.php" method="post">
<fieldset>
<input type="hidden" name="redirect"
value="<?php echo $_POST['redirect']; ?>">
<legend>Log in:</legend>
            <p>
                <label for="Username">
                   Username:</label><input type="text" name="username"><br></p>
            <p>
                <label for="Password">
                    Password:</label>
 
<input type="password" name="password"></p>
<input type="submit" name="submit" value="Login">
</fieldset>
</form>
</p>
</div>
<?php
}
} else {
?>
<html>
<head>
<title>Login</title>
<link rel="stylesheet" type="text/css" media="screen" href="style.php">
</head>
<body>

<div id="page-wrap">
<p>
<?
if (isset($_GET['redirect'])) {
$redirect = $_GET['redirect'];
} else {
$redirect = "index.php";
}
?>
<form action="login.php" method="post">
<fieldset>
<input type="hidden" name="redirect"
value="<?php echo $_GET['redirect']; ?>">
<legend>Log in:</legend>
            <p>
                <label for="Username">
                   Username:</label>
                    <input type="text" name="username"><br>
                   </p>
            <p>
                <label for="Password">
                    Password:</label>
 <input type="password" name="password"></p>
<input type="submit" name="submit" value="Login">
</fieldset>
</form>
</p>
</div>
<?php
}
?>
</body>
</html>