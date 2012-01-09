<html>
<head>
<title>Personal Information</title>
</head>
<body>
<h1>Welcome to your personal information area</h1>
<p>
	Here you can update your personal information,
	or delete your account.<br>
	Your information as you currently have it is shown below:<br>
	<a href="index.php">Click here</a> to return to the home page<br><br>
<?php
$query = "SELECT * FROM it_people " .
	 "WHERE username = '" . $_SESSION['user_logged'] . "' " .
	 "AND password = (PASSWORD('" .
	 $_SESSION['user_password'] . "'))";
$result = mysql_query($query)
  or die(mysql_error());
$row = mysql_fetch_array($result);
?>
	First Name: <?php echo $row['first_name']; ?><br>
	Last Name: <?php echo $row['last_name']; ?><br>
	Email: <?php echo $row['email']; ?><br><br>
	<a href="update_account.php">Update Account</a> |
	<a href="delete_account.php">Delete Account</a>
</p>
</body>
</html>