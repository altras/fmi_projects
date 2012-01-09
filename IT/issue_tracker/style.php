<?php
header("Content-type: text/css");
$float= 'left';
?>
legend{ color:black;}
b
        {
            float: left;
            display: block;
            width:12em;
            text-align: right;
            color:black;
        }
label
        {
            width:5em;
            float: left;
            text-align: right;
            display: block;
            color:black;
        }
		#page-wrap
        {
            position: relative;
            z-index: 2;
            width: 400px;
            margin: 30px auto;
            padding: 15px;
            -moz-box-shadow: 0 0 20px black;
            -webkit-box-shadow: 0 0 20px black;
            box-shadow: 0 0 20px black;
            color:black;
            font-size:14px;
            
        }
        p
        {
            font: 15px/2 Georgia, Serif;
            margin: 0 0 10px 20px;
            text-indent: 40px;
        }
.field{
 float:<?=$float?>;
}
body {margin:0; font-family:"Trebuchet MS", Helvetica, sans-serif; background: url(images/body.jpg) repeat-x center top #FFFFFF;}
a {color:#21334A;}
a:hover {text-decoration:none;}

#contentMain .panelLast {
    border-bottom: 0 none #FFFFFF;
    min-height: 160px;
}

#contentMain .panel {
    background-image: url("../images/panel.jpg");
    background-repeat: repeat-x;
    border-color: #000000 #7F7F7F #7F7F7F #FFFFFF;
    border-right: 1px solid #7F7F7F;
    border-style: solid;
    border-width: 11px;
    padding-top: 21px;
}

.panel {
    padding: 20px;
}





#container {width:974px; margin:0 auto; margin-top:40px; background:url(images/main.jpg) no-repeat #FFFFFF;}

#logo {padding:20px 37px 0 37px;}
#logo a {color:#FFFFFF; text-decoration:none; text-transform:uppercase; font-size:20px;}
#menu {margin:148px 22px 0 22px;}
#menu ul {padding:0; margin:0; height:29px;}
#menu li {list-style:none; float:left; padding:0 15px;}
#menu a {color:#FFFFFF; text-decoration:none; font-size:14px; line-height:24px; text-transform:lowercase;}
#menu a:hover {border-bottom:2px #FFFFFF solid;}

#main {font-size:11px; line-height:16px; color:#21334A;}
#text {padding:10px 281px 30px 37px;}
#text h1, #text h2 {font-size:20px; font-weight:normal; text-transform:uppercase; margin:20px 0 10px 0;}
#text ul {margin-top:8px; margin-bottom:8px;}


#footer {clear:both; height:120px; background:url(images/footer.jpg) no-repeat; font-size:11px; color:#21334A;}
#footer a {color:#000000;}
#menu_footer {padding:18px 37px 0 37px; text-transform:lowercase;}
#left_footer {float:left;padding:36px 0 0 37px;}