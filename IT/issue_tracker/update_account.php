<html>
<head>
<title>Update Account Information</title>
</head>
<body>
<h1>Update Account Information</h1>
<p>
	Here you can update your account information for viewing in your
	profile.<br><br>
<?php
if (isset($_POST['submit']) && $_POST['submit'] == "Update") {
	$query_update = "UPDATE it_people SET " .
			"email = '" . $_POST['email'] . "', " .
			"' WHERE username = '" . $_SESSION['user_logged'] .
			"' AND password = (PASSWORD('" .
			$_SESSION['user_password'] . "'))";
	$result_update = mysql_query($query_update)
	  or die(mysql_error());

	$query = "SELECT * FROM it_people " .
		 "WHERE username = '" . $_SESSION['user_logged'] . "' " .
		 "AND password = (PASSWORD('" .
		 $_SESSION['user_password'] . "'))";
	$result = mysql_query($query)
	  or die(mysql_error());

	$row = mysql_fetch_array($result);
?>
	<b>Your account information has been updated.</b><br>
	<a href="user_personal.php">Click here</a> to return to your account.
	<form action="update_account.php" method="post">
		Email: <input type="text" name="email"
			value="<?php echo $row['email']; ?>"><br>
		<input type="submit" name="submit" value="Update"> &nbsp;
		<input type="button" value="Cancel" onclick="history.go(-1);">
</form>
</p>

<?php
} else {
	$query = "SELECT * FROM it_people " .
		 "WHERE username = '" . $_SESSION['user_logged']. "' " .
		 "AND password = (PASSWORD('" .
		 $_SESSION['user_password'] . "'));";
	$result = mysql_query($query)
	  or die(mysql_error());
	$row = mysql_fetch_array($result);
?>

<p>
	<form action="update_account.php" method="post">
		Email: <input type="text" name="email"
			value="<?php echo $row['email']; ?>"><br>
		<input type="submit" name="submit" value="Update"> &nbsp;
		<input type="button" value="Cancel" onclick="history.go(-1);">
	</form>
</p>
<?php
}
?>
</body>
</html>