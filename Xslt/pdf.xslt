<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
  <xsl:template match="/">
    <fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">
      <fo:layout-master-set>
        <fo:simple-page-master master-name="Invoices" page-height="11in" page-width="8.5in">
          <fo:region-body region-name="only_region" margin="1in" background-color="#CCCCCC"/>
        </fo:simple-page-master>
      </fo:layout-master-set>
      <xsl:for-each select="report/invoice">
        <fo:page-sequence master-reference="Invoices">
          <fo:flow flow-name="only_region">
            <fo:table border="0.5pt solid black">
              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell padding="6pt" text-align="left">
                    <fo:block>
                      <xsl:value-of select="invoiceCust/firstname"/>
                      <xsl:text> </xsl:text>
                      <xsl:value-of select="invoiceCust/lastname"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell padding="6pt" text-align="right">
                    <fo:block>
                      Date: <fo:inline font-weight="bold">
                        <xsl:value-of select="invoiceDate"/>
                      </fo:inline>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <fo:table-row>
                  <fo:table-cell padding="6pt" text-align="left">
                    <fo:block>
                      <xsl:value-of select="invoiceCust/companyId"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <fo:table-row>
                  <fo:table-cell padding="6pt" text-align="left">
                    <fo:block>
                      <xsl:value-of select="invoiceCust/address"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <fo:table-row>
                  <fo:table-cell padding="6pt" text-align="left">
                    <fo:block>
                      <xsl:value-of select="invoiceCust/zipCode"/>, <xsl:value-of select="invoiceCust/countryCode"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <fo:table-row>
                  <fo:table-cell padding="6pt" text-align="left">
                    <fo:block>
                      Additional text: <xsl:value-of select="invoiceText"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
            <fo:table border="0.5pt solid black">
              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell padding="6pt" border="0.5pt solid black" text-align="center">
                    <fo:block>
                      Invoice ID: <xsl:value-of select="invoiceNumber"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <fo:table-row>
                  <fo:table-cell text-align="center" border="0.5pt solid black">
                    <fo:block>Name</fo:block>
                  </fo:table-cell>
                  <fo:table-cell text-align="center" border="0.5pt solid black">
                    <fo:block>Price</fo:block>
                  </fo:table-cell>
                  <fo:table-cell text-align="center" border="0.5pt solid black">
                    <fo:block>Amount</fo:block>
                  </fo:table-cell>
                  <fo:table-cell text-align="center" border="0.5pt solid black">
                    <fo:block>Full price</fo:block>
                  </fo:table-cell>
                  <fo:table-cell text-align="center" border="0.5pt solid black">
                    <fo:block>Full VAT</fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <xsl:for-each select="invoiceLines/invoiceLine">
                  <fo:table-row>
                    <fo:table-cell text-align="center" border="0.5pt solid black">
                      <fo:block>
                        <xsl:value-of select="product"/>
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell text-align="center" border="0.5pt solid black">
                      <fo:block>
                        <xsl:value-of select="productPrice"/>
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell text-align="center" border="0.5pt solid black">
                      <fo:block>
                        <xsl:value-of select="productQuantity"/>
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell text-align="center" border="0.5pt solid black">
                      <fo:block>
                        <xsl:value-of select="linePrice"/>
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell text-align="center" border="0.5pt solid black">
                      <fo:block>
                        <xsl:value-of select="lineVat"/>
                      </fo:block>
                    </fo:table-cell>
                  </fo:table-row>
                </xsl:for-each>
              </fo:table-body>
            </fo:table>
          </fo:flow>
        </fo:page-sequence>
      </xsl:for-each>
    </fo:root>
  </xsl:template>
</xsl:stylesheet>