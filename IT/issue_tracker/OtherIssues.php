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
<script type="text/javascript">
 function openWin(url,height,width)
    {
             window.open(url, "_blank","height=" + height + ",width=" + width + ", location=0, menubar=0,r esizable=0,s crollbars=0, status=0,status=0,toolbar=0")
    }
    function tdStyle(obj,value)
    {
        if ( value ) 
        { 
            obj.style.cursor = "pointer"; 
            obj.style.color = "blue"
        }
        else 
        { 
            obj.style.cursor = "auto"; 
            obj.style.color = "black"
        }
    }
</script>

<div id="main">
<div id="text">
<h1>Welcome. These are your issues</h1>
<?php
require_once "conn.php";
//the current logged user
$user_id = $_SESSION["id"];
//$user_id = 1;
//gets the user other issues
$otherIssues = "SELECT * FROM it_issue WHERE issue_id NOT
	IN (
	SELECT person
	FROM it_schedule
	WHERE person = $user_id
	)
	LIMIT 0 , 30";

$resultIssues = mysql_query($otherIssues) or die(mysql_error());
$numRows = mysql_num_rows($resultIssues);//for little optimization

if ($numRows > 0){

while($issue = mysql_fetch_array($resultIssues, MYSQL_BOTH)){
	$tempAssignee = $issue['issue_id'];
	$tempStatus = $issue['status'];
	$tmpType = $issue['type'];	
	$queryType = mysql_query("SELECT it_type.type_description
		FROM it_type
		WHERE it_type.type_id = $tmpType
		LIMIT 0 , 30") or die(mysql_error());
	$type = mysql_fetch_array($queryType, MYSQL_BOTH);
	echo "<div  id=\"page-wrap\" onclick=openWin(\"tchange.php?id=$issue[issue_id]\",\"500px\",\"1000px\")  onmouseover=\"tdStyle(this,true)\" onmouseout=\"tdStyle(this,false)\">";
//echo "<br/>---------------------------------------------------------------<br/>"; 
//status image
	echo "<a ><img src='images/" . "$tempStatus" . ".png'/></a>";
//title link button
	echo $type['type_description'].":<a >".  $issue['issue_description'] . "</a>";
//query for Assignees
	$queryAssignees = "SELECT it_people.person_firstname, it_people.person_lastname
	FROM it_people
	INNER JOIN it_schedule ON it_schedule.person = it_people.person_id
	WHERE it_schedule.issue = $tempAssignee
	LIMIT 0 , 30
 	";
	$resultQuery = mysql_query($queryAssignees) or die(mysql_error());
	echo "<br/>Assignees:"  ;
//print Assignees
	while($assignee=mysql_fetch_array($resultQuery, MYSQL_BOTH)){	
		echo " " . $assignee['person_firstname'] . " " . $assignee['person_lastname'] . ", ";
	
	}	
	echo "</div>";
}
}
else 
	echo "You don't attend issues. You can go _HERE_ to start working on something";


mysql_close($con);
?>
</div>

</div>
<!-- end main -->
<!-- footer -->
<?php require('footer.php')?>
<!-- end footer -->
</div>
</body>
</html> 
