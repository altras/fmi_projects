<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" encoding="UTF-8" indent='yes' doctype-public="-//W3C//DTD HTML 4.01//EN" 
        doctype-system="http://www.w3.org/TR/1999/REC-html401-19991224/strict.dtd"/>
        <xsl:template match="/">
        <html>
        	<body>
        		<h1>Quake Server 1</h2>
		        <table border="1px" align="center" style="color:#ffffff; font-family: Arial Black; font-weight: bold; font-size: 20px;">
		        	<xsl:for-each select="Weapons/Name">
		        		<tr>
		        			<td>Range:</td>
		        			<td><xsl:value-of select="Range"/></td>
		        			<td><xsl:value-of select="Damage"/></td>
		        		</tr>
		        	</xsl:for-each>
		        </table>
		    </body>
		</html>

		<xsl:template>
</xsl:stylesheet>