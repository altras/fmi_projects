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
session_start();
require_once "conn.php";
//the current logged user
$user_id = $_SESSION["id"];
//$user_id = 1;

//gets the user issues
$yourIssues = "SELECT it_issue.issue_title, it_schedule.issue, it_issue.status, it_issue.type,it_issue.issue_id
FROM it_issue
INNER JOIN it_schedule ON it_issue.issue_id = it_schedule.issue
WHERE it_schedule.person = $user_id
LIMIT 0 , 30";

$resultIssues = mysql_query($yourIssues) or die(mysql_error());
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
	 echo "<div id=\"page-wrap\" onclick=openWin(\"tchange.php?id=$issue[issue_id]\",\"500px\",\"1000px\")  onmouseover=\"tdStyle(this,true)\" onmouseout=\"tdStyle(this,false)\">";
//echo "<br/>---------------------------------------------------------------<br/>"; 
//status image
	echo "<a ><img src='images/" . "$tempStatus" . ".png'/></a>";
//title link button
	echo $type['type_description'].":<a>".  $issue['issue_title'] . "</a>";
//query for Assignees
	$queryAssignees = "SELECT it_people.person_firstname, it_people.person_lastname
 FROM it_people
 INNER JOIN it_schedule ON it_schedule.person = it_people.person_id
 WHERE it_schedule.issue = $tempAssignee
 LIMIT 0 , 30";
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
