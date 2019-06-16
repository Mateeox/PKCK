<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:key name="customersList" match="customer" use="@customerId" />
<xsl:key name="productsList" match="product" use="@productId" />
<xsl:key name="currenciesList" match="currency" use="@curr" />
<xsl:template match="/">
	<report>
		<xsl:for-each select="document/invoices/invoice">
			<invoice>
				<invoiceNumber><xsl:value-of select="invoiceNumber"/></invoiceNumber>
				<invoiceDate><xsl:value-of select="invoiceDate"/></invoiceDate>
				<invoiceText><xsl:value-of select="additionalText"/></invoiceText>
				<xsl:variable name="customer"><xsl:value-of select="invoiceCustomer/@customerRef"/></xsl:variable>
				<invoiceCust>
					<xsl:for-each select="key('customersList', $customer)">
						<firstname><xsl:value-of select="firstname"/></firstname>
						<lastname><xsl:value-of select="lastname"/></lastname>
						<companyId><xsl:value-of select="companyId"/></companyId>
						<address><xsl:value-of select="address"/></address>
						<zipCode><xsl:value-of select="zipCode"/></zipCode>
						<countryCode><xsl:value-of select="countryCode"/></countryCode>
					</xsl:for-each>
				</invoiceCust>
				<invoiceLines>
					<xsl:for-each select="invoiceLines/invoiceLine">
					<xsl:sort select="invoiceProduct/@productRef"/>
						<xsl:variable name="product"><xsl:value-of select="invoiceProduct/@productRef"/></xsl:variable>
						
						<xsl:variable name="quant"><xsl:value-of select="quantity"/></xsl:variable>
						<xsl:variable name="vat"><xsl:value-of select="vatValue"/></xsl:variable>
						<xsl:variable name="vatType"><xsl:value-of select="vatValue/@type"/></xsl:variable>
						<invoiceLine>
							<xsl:for-each select="key('productsList', $product)">
								<product><xsl:value-of select="producer"/><xsl:text> </xsl:text><xsl:value-of select="name"/></product>
								<productQuantity><xsl:value-of select="$quant"/></productQuantity>
								<productPrice><xsl:value-of select="curr/@currencyRef"/><xsl:text> </xsl:text><xsl:value-of select="price"/></productPrice>
								<linePrice><xsl:value-of select="curr/@currencyRef"/><xsl:text> </xsl:text><xsl:value-of select="format-number($quant * price, '#.00')"/></linePrice>
								<lineVat><xsl:value-of select="curr/@currencyRef"/><xsl:text> </xsl:text><xsl:value-of select="format-number($quant * price * $vat div 100.0, '#.00')"/></lineVat>

								<xsl:variable name="currency"><xsl:value-of select="curr/@currencyRef"/></xsl:variable>
								<xsl:variable name="price"><xsl:value-of select="format-number(price, '#.00')"/></xsl:variable>
								<xsl:variable name="priceTimesQuantity"><xsl:value-of select="format-number($quant * price, '#.00')"/></xsl:variable>
								<xsl:variable name="priceTimesQuantityTimesVAT"><xsl:value-of select="format-number($quant * price * $vat div 100.0, '#.00')"/></xsl:variable>
								<xsl:for-each select="key('currenciesList', $currency)">
									<productPriceInPLN><xsl:text>PLN </xsl:text><xsl:value-of select="format-number($price * toPLN, '#.00')"/></productPriceInPLN>
									<linePriceInPLN><xsl:text>PLN </xsl:text><xsl:value-of select="format-number($priceTimesQuantity * toPLN, '#.00')"/></linePriceInPLN>
									<lineVatInPLN><xsl:text>PLN </xsl:text><xsl:value-of select="format-number($priceTimesQuantityTimesVAT * toPLN div 100.0, '#.00')"/></lineVatInPLN>
								</xsl:for-each>
								<lineVatPre>
									<xsl:attribute name="type">
										<xsl:value-of select="$vatType" />
									</xsl:attribute>
									<xsl:value-of select="$vat"/>
								</lineVatPre>
							</xsl:for-each>
						</invoiceLine>
					</xsl:for-each>
				</invoiceLines>
			</invoice>			
		</xsl:for-each>
	</report>
</xsl:template>
</xsl:stylesheet>