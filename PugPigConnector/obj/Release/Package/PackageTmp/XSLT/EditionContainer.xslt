<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output indent="yes" />
  <xsl:output method="html"/>
  <xsl:template match="/">    
    <feed xmlns="http://www.w3.org/2005/Atom" xmlns:dcterms="http://purl.org/dc/terms/" xmlns:opds="http://opds-spec.org/2010/catalog" xmlns:app="http://www.w3.org/2007/app">
      <id>
        <xsl:value-of select="/editionList/pageId"/>
      </id>
      <link rel="self" type="application/atom+xml;profile=opds-catalog;kind=acquisition">
        <xsl:attribute name="href">
          <xsl:value-of select="/editionList/href"/>
        </xsl:attribute>  
      </link>    
      <title>
        <xsl:value-of select="/editionList/title"/>
      </title>
      <updated>
        <xsl:value-of select="/editionList/updated"/>
      </updated>
      <author>
        <name>
          <xsl:value-of select="/editionList/authorname"/>
        </name>
      </author>
      <xsl:for-each select="/editionList/edition">
        <entry> 
          <title>
            <xsl:value-of select="title"/>
          </title>
          <id>
            <xsl:value-of select="id"/>
          </id>
          <updated>
            <xsl:value-of select="updated"/>
          </updated>
          <author>
            <name>
              <xsl:value-of select="authorname"/>
            </name>
          </author>
          <dcterms:issued>
            <xsl:value-of select="issued"/>
          </dcterms:issued>
          <summary type="text">
            <xsl:value-of select="summary"/>
          </summary>
          <link rel="http://opds-spec.org/image" type="image/jpg" href="img/cover.jpg">
            <xsl:attribute name="href">
              <xsl:value-of select="imagehref"/>
            </xsl:attribute>
          </link>
          <link rel="http://opds-spec.org/acquisition" type="application/atom+xml" href="edition1.xml">
            <xsl:attribute name="href">
              <xsl:value-of select="editionContent"/>
            </xsl:attribute>            
          </link>
          <link rel="alternate" type="application/atom+xml" href="edition1.xml">
            <xsl:attribute name="href">
              <xsl:value-of select="alternatehref"/>
            </xsl:attribute>
          </link>  
        </entry>   
      </xsl:for-each>
    </feed>  
  </xsl:template>
</xsl:stylesheet>
