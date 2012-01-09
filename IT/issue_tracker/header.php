<!-- header -->
<div id="logo"><a href="#">Issue Tracker</a></div>
<div id="menu">
<ul>
<li><a href="index.php">my issues</a></li>
<li><a href="OtherIssues.php">other issues</a></li>
<li><a href="CreateIssue.php">create issue</a></li>
<li><a href="logout.php">logout</a></li>
<li><a href="signissue.php">sign issue</a></li>
<li><a href="unsignissue.php">unsign issue</a></li>
<?php
if($_SESSION["id"]==1)echo "<li><a href=\"register.php\">register</a></li>";
?>
</ul>
</div>
<!--end header -->