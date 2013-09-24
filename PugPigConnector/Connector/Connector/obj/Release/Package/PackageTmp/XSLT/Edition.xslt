<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output indent="yes" />
  <xsl:output method="html"/>
  <xsl:template match="/">
    <feed xmlns="http://www.w3.org/2005/Atom">
      <id>
        <xsl:value-of select="/edition/pageId"/>
      </id>
      <link rel="self" type="application/atom+xml">
        <xsl:attribute name="href">
          <xsl:value-of select="/edition/href"/>
        </xsl:attribute>
      </link>
      <title type="text">
        <xsl:value-of select="/edition/title"/>
      </title>
      <subtitle type="text">
        <xsl:value-of select="/edition/subtitle"/>
      </subtitle>
      <author>
        <name>
          <xsl:value-of select="/edition/authorname"/>
        </name>
      </author>
      <updated>
        <xsl:value-of select="/edition/updated"/>
      </updated>
      <xsl:for-each select="/edition/page">
        <entry>
          <id>
            <xsl:value-of select="pageId"/>
          </id>
          <link rel="alternate" type="text/html">
            <xsl:attribute name="href">
              <xsl:value-of select="pageLink"/>
            </xsl:attribute>
          </link>          
          <link rel="related" type="text/cache-manifest">
            <xsl:attribute name="href">
              <xsl:value-of select="manifestLink"/>
            </xsl:attribute>
          </link>  
          <title type="text">
            <xsl:value-of select="title"/>
          </title>
          <summary type="text">
            <xsl:value-of select="summary"/>
          </summary>
          <updated>
            <xsl:value-of select="updated"/>
          </updated>
        </entry>
      </xsl:for-each>
    </feed> 
  </xsl:template>
</xsl:stylesheet>
