<?php

if (isset($_POST['submit']) && $_POST['submit'] == "Yes") {
	$query_delete = "DELETE FROM it_people " .
			"WHERE username = '" . $_SESSION['user_logged'] .
			"' AND password = (PASSWORD('" .
			$_SESSION['user_password'] . "'))";
	$result_delete = mysql_query($query_delete)
	  or die(mysql_error());

	$_SESSION['user_logged'] = "";
	$_SESSION['user_password'] = "";

	header("Refresh: 5; URL=index.php");
	echo "Your account has been deleted! You are being sent to the " .
		"home page!<br>";
	echo "(If you're browser doesn't support this, " .
		"<a href=\"index.php\">click here</a>)";
	die();
} else {
?>
<html>
<head>
<title>Delete account</title>
</head>
<body>
<p>
	Are you sure you want to delete your account?<br>
	There is no way to retrieve your account once you confirm!<br>
	<form action="delete_account.php" method="post">
		<input type="submit" name="submit" value="Yes"> &nbsp;
		<input type="button" value=" No " onclick="history.go(-1);">
	</form>
</p>
</body>
</html>
<?php
}
?>