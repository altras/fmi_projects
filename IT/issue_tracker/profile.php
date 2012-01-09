<?php    
require_once "conn.php";
$id=$_SESSION['id'];


  // run this only, once the user has hit the "Update" button

  if (isset($_POST['submit'])) {

    // assign form inputs
    $username= $_POST['username'];
    $id= $_POST['id'];
    $password= $_POST['password'];

    $person_email= $_POST['person_email'];

    $issue_user_created= $_POST['issue_user_created'];

    $issue_time_created= $_POST['issue_time_created'];

      // add member to database

    $result = mysql_query("UPDATE it_issue SET username='".$username."',password='".$password."',person_email='".$person_email."' WHERE issue_id='".$id."'");
        mysql_close($con);
      echo "<SCRIPT LANGUAGE=\"JavaScript\">window.close();</SCRIPT>";exit;
      
      exit;
    }


  else { // read member data from database

    $result = mysql_query ("SELECT * FROM it_issue WHERE issue_id='".$id."'");
    while($row = mysql_fetch_array($result))


{


   $issue_title= $row['issue_title'];

    $status= $row['status'];

    $person_email= $row['person_email'];

    $issue_user_created= $row['issue_user_created'];

    $issue_time_created= $row['issue_time_created'];

  }
  }
  mysql_close($con);
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
<div id="page-wrap">
<form action="profile.php" method="post"><fieldset><legend>profile:</legend>
<p>
           
                <label for="Username">
                   Username:</label>
<input type="text" id="username" name="username" value="<?php echo $username?>" /><br></p>
        <p>       <label for="Username">
                   Username:</label>
<input type="text" id="username" name="password" value="<?php echo $password?>" /><br></p>
<p>       <label for="Username">
                   Username:</label>
<input type="text" id="username" name="person_email" value="<?php echo $person_email?>" /><br></p>
<p> <label for="Username">
                   status:</label>
<select name="status">
<?
 $con = mysql_connect("localhost","onehourb_tracker","tracker");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }

mysql_select_db("onehourb_itdb", $con);

$qry ="SELECT * FROM it_person_role";
$res = mysql_query($qry );

while ($game = mysql_fetch_row($res)) {
echo("
<option value='$game[0]'>$game[1]</option>
"); 
}
mysql_close($con);
?>
</select><br /></p>
<input type="hidden" id="id" name="id" value="<?php echo $id?>" />
<input type="submit" name="submit" value="Update">
</fieldset></form>
</div>
<?php require('footer.php')?>
<!-- end footer -->
</div>
</body>
</html> 