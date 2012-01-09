<?php
session_start();
$a=$_SESSION["id"];
if($_SESSION["logged"]!=1) 
{header("Location: login.php");}   
require_once "conn.php";
$id=$_GET['id'];
  if (isset($_POST['submit'])) {
    $issue_title= $_POST['issue_title'];
    $id= $_POST['id'];
    $status= $_POST['status'];
    $issue_description= $_POST['issue_description'];
    $issue_user_created= $_POST['issue_user_created'];
    $issue_time_created= $_POST['issue_time_created'];

    $result = mysql_query("UPDATE it_issue SET issue_title='".$issue_title."',status='".$status."',issue_description='".$issue_description."' WHERE issue_id='".$id."'");
        mysql_close($con);
 echo "UPDATE it_issue SET issue_title='".$issue_title."',status='".$status."',issue_description='".$issue_description."',issue_user_created='".$issue_user_created."',issue_time_created='".$issue_time_created."' WHERE issue_id='".$id."'";
     echo "<SCRIPT LANGUAGE=\"JavaScript\">window.close();</SCRIPT>";exit;
      
      exit;
    }


  else { // read member data from database
    echo "bla";
    $result = mysql_query ("SELECT * FROM it_issue WHERE issue_id='".$id."'");
    while($row = mysql_fetch_array($result))


{


   $issue_title= $row['issue_title'];

    $status= $row['status'];

    $issue_description= $row['issue_description'];

    $issue_user_created= $row['issue_user_created'];

    $issue_time_created= $row['issue_time_created'];

  }
  }
  mysql_close($con);
?>
<html><head><title>change</title>
<link rel="stylesheet" type="text/css" media="screen" href="style.php">
</head><body><div id="page-wrap">
<form action="tchange.php" method="post"><fieldset><legend>Info:</legend>
<p>
           
                <label for="Username">
                   title:</label>
<input type="text" id="issue_title" name="issue_title" value="<?php echo $issue_title?>" /><br></p>
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

$qry ="SELECT * FROM it_status";
$res = mysql_query($qry );

while ($game = mysql_fetch_row($res)) {
echo("
<option value='$game[0]'>$game[1]</option>
"); 
}
mysql_close($con);
?>
</select><br /></p>
<p> <label for="Username">
                   description:</label>
<textarea rows="2" cols="20" id="issue_description" name="issue_description"><?php echo $issue_description ?></textarea><br></p>
 <input type="hidden" id="id" name="id" value="<?php echo $id?>" />
<input type="submit" name="submit" value="Update">
</fieldset></form>
</div>
</body></html>