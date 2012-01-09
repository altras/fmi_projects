<?php 
define('SQL_HOST','localhost');
define('SQL_USER','onehourb_tracker');
define('SQL_PASS','tracker');
define('SQL_DB','onehourb_itdb');

$con = mysql_connect(SQL_HOST,SQL_USER,SQL_PASS) or
	die('Couldn\'t connect to the DB:' . mysql_error());
mysql_select_db(SQL_DB,$con) or
	die ('Couldn\'t select the DB:' . mysql_error());

?>