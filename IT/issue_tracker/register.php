<?php
session_start();
$a=$_SESSION["id"];
$_SESSION["add"]=$a;
if($_SESSION["logged"]!=1) 
{header("Location: login.php");}
function isValidEmail($email){
      $pattern = "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$";
     
      if (eregi($pattern, $email)){
         return true;
      }
      else {
         return false;
      }   
   }
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
<?php
if (isset($_POST['submit']) && $_POST['submit'] == "Register") {
	if ($_POST['username'] != "" &&
	    $_POST['password'] != "" &&
	    $_POST['person_firstname'] != "" &&
	    $_POST['person_lastname'] != "" &&
	    $_POST['person_email'] != "") {
	   require_once "conn.php";


	$query = "SELECT username FROM it_people " .
		 "WHERE username = '" . $_POST['username'] . "';";
	$result = mysql_query($query)
	  or die(mysql_error());

	if (mysql_num_rows($result) != 0) {
?>
<div id="page-wrap">
<p>
	<font color="#FF0000">The Username,
	<?php echo $_POST['username']; ?>, is already in use, please choose another!</font>
	<form action="register.php" method="post"><fieldset><legend>Registration:</legend>
		 <p>
                <label for="Username">
                   Username:</label><input type="text" name="username"><br></p>
		<p> <label for="password">
                   password:</label><input type="password" name="password"
			value="<?php echo $_POST['password']; ?>"><br>
		<p> <label for="password">
                   firstname:</label><input type="text" name="person_firstname"
			value="<?php echo $_POST['person_firstname']; ?>"><br></p>
		<p> <label for="password">
                   lastname::</label><input type="text" name="person_lastname"
			value="<?php echo $_POST['person_lastname']; ?>"><br></p>
		<p> <label for="password">
                   email:</label><input type="text" name="person_email"
			value="<?php echo $_POST['person_email']; ?>"><br></p>
		<input type="submit" name="submit" value="Register"> &nbsp;
		<input type="reset" value="Clear"></fieldset>
	</form>
</p></div>
<?php
} else {            if (isValidEmail($_POST['person_email'])){
               
            
	$pass=sha1($_POST['password']);
	$query = "INSERT INTO it_people (username, password, person_firstname, " .
		 "person_lastname, person_email, person_role) " .
		 "VALUES ('" . $_POST['username'] . "','" .  
		 $pass . "','" . 
		 $_POST['person_firstname'] . "','" . 
		 $_POST['person_lastname'] . "','" . 
		 $_POST['person_email'] . "','2');";

	$result = mysql_query($query)
	  or die(mysql_error());
	mysql_close($con);
	  echo "<div id=\"page-wrap\">";
	echo "Your registration is complete!<br>";
	echo "</div>";
	}
            else{
                echo "<div id=\"page-wrap\">";
                echo "The email: ".$_POST['person_email']." is invalid!";
                echo "</div>";
            }
?>
<?php
	
}
} else {
?>
<div id="page-wrap">
<p>
	<font color="#FF0000">The Username, Password, E-mail, First Name, and Last Name fields are required!</font>
	<form action="register.php" method="post"><fieldset><legend>Registration:</legend>
		 <p>
                <label for="Username">
                   Username:</label><input type="text" name="username"
                   value="<?php echo $_POST['username']; ?>"><br></p>
		<p> <label for="password">
                   password:</label><input type="password" name="password"
			value="<?php echo $_POST['password']; ?>"><br>
		<p> <label for="password">
                   firstname:</label><input type="text" name="person_firstname"
			value="<?php echo $_POST['person_firstname']; ?>"><br></p>
		<p> <label for="password">
                   lastname:</label><input type="text" name="person_lastname"
			value="<?php echo $_POST['person_lastname']; ?>"><br></p>
		<p> <label for="password">
                   email:</label><input type="text" name="person_email"
			value="<?php echo $_POST['person_email']; ?>"><br></p>
		<input type="submit" name="submit" value="Register">
		<input type="reset" value="Clear"></fieldset>
	</form>
</p>
</div>
<?php
}
} else {
?>
<div id="page-wrap">
<p>
	<font color="#FF0000">Welcome to the registration page!<br>
	The Username, Password, E-mail, First Name, and Last Name fields
	are required!<label></form>
	<form action="register.php" method="post"><fieldset><legend>Registration:</legend>
		 <p>
                <label for="Username">
                   Username:</label> <input type="text" name="username"><br></p>
		<p>
                <label for="Username">
                   password:</label>  <input type="password" name="password"><br></p>
		<p>
                <label for="Username">
                   firstname:</label>  <input type="text" name="person_firstname"><br></p>
		<p>
                <label for="Username">
                   lastname:</label>  <input type="text" name="person_lastname"><br></p>
		<p>
                <label for="Username">
                   email:</label>  <input type="text" name="person_email"><br></p>
		<input type="submit" name="submit" value="Register"> &nbsp;
		<input type="reset" value="Clear">
	</form></fieldset>
</p>
</div>
<?php
}
?>
<?php require('footer.php')?>
<!-- end footer -->
</div>
</body>
</html> 