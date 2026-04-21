
import os

xsd_path = "/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/CLI/CLIDataSet.xsd"

table_defs = """        <xs:element name="T_Cloture" msprop:Generator_TableVarName="tableT_Cloture" msprop:Generator_TableClassName="T_ClotureDataTable" msprop:Generator_RowClassName="T_ClotureRow" msprop:Generator_RowChangingName="T_ClotureRowChanging" msprop:Generator_UserTableName="T_Cloture" msprop:Generator_RowChangedName="T_ClotureRowChanged" msprop:Generator_TablePropName="T_Cloture" msprop:Generator_RowEvArgName="T_ClotureRowChangeEvent" msprop:Generator_RowDeletingName="T_ClotureRowDeleting" msprop:Generator_RowDeletedName="T_ClotureRowDeleted" msprop:Generator_RowEvHandlerName="T_ClotureRowChangeEventHandler">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="Id_Cloture" msdata:ReadOnly="true" msdata:AutoIncrement="true" msprop:Generator_ColumnVarNameInTable="columnId_Cloture" msprop:Generator_UserColumnName="Id_Cloture" msprop:Generator_ColumnPropNameInRow="Id_Cloture" msprop:Generator_ColumnPropNameInTable="Id_ClotureColumn" type="xs:long" />
              <xs:element name="DateCloture" msprop:Generator_ColumnVarNameInTable="columnDateCloture" msprop:Generator_UserColumnName="DateCloture" msprop:Generator_ColumnPropNameInRow="DateCloture" msprop:Generator_ColumnPropNameInTable="DateClotureColumn" type="xs:dateTime" />
              <xs:element name="TypeCloture" msprop:Generator_ColumnVarNameInTable="columnTypeCloture" msprop:Generator_UserColumnName="TypeCloture" msprop:Generator_ColumnPropNameInRow="TypeCloture" msprop:Generator_ColumnPropNameInTable="TypeClotureColumn">
                <xs:simpleType>
                  <xs:restriction base="xs:string">
                    <xs:maxLength value="20" />
                  </xs:restriction>
                </xs:simpleType>
              </xs:element>
              <xs:element name="MontantTotal_Jour_TTC" msprop:Generator_ColumnVarNameInTable="columnMontantTotal_Jour_TTC" msprop:Generator_UserColumnName="MontantTotal_Jour_TTC" msprop:Generator_ColumnPropNameInRow="MontantTotal_Jour_TTC" msprop:Generator_ColumnPropNameInTable="MontantTotal_Jour_TTCColumn" type="xs:decimal" />
              <xs:element name="GrandTotal_Perpetuel_TTC" msprop:Generator_ColumnVarNameInTable="columnGrandTotal_Perpetuel_TTC" msprop:Generator_UserColumnName="GrandTotal_Perpetuel_TTC" msprop:Generator_ColumnPropNameInRow="GrandTotal_Perpetuel_TTC" msprop:Generator_ColumnPropNameInTable="GrandTotal_Perpetuel_TTCColumn" type="xs:decimal" />
              <xs:element name="PremierTicketID" msprop:Generator_ColumnVarNameInTable="columnPremierTicketID" msprop:Generator_UserColumnName="PremierTicketID" msprop:Generator_ColumnPropNameInRow="PremierTicketID" msprop:Generator_ColumnPropNameInTable="PremierTicketIDColumn" type="xs:long" minOccurs="0" />
              <xs:element name="DernierTicketID" msprop:Generator_ColumnVarNameInTable="columnDernierTicketID" msprop:Generator_UserColumnName="DernierTicketID" msprop:Generator_ColumnPropNameInRow="DernierTicketID" msprop:Generator_ColumnPropNameInTable="DernierTicketIDColumn" type="xs:long" minOccurs="0" />
              <xs:element name="Signature" msprop:Generator_ColumnVarNameInTable="columnSignature" msprop:Generator_UserColumnName="Signature" msprop:Generator_ColumnPropNameInRow="Signature" msprop:Generator_ColumnPropNameInTable="SignatureColumn" type="xs:string" />
              <xs:element name="PreviousSignature" msprop:Generator_ColumnVarNameInTable="columnPreviousSignature" msprop:Generator_UserColumnName="PreviousSignature" msprop:Generator_ColumnPropNameInRow="PreviousSignature" msprop:Generator_ColumnPropNameInTable="PreviousSignatureColumn" type="xs:string" />
              <xs:element name="CreePar" msprop:Generator_ColumnVarNameInTable="columnCreePar" msprop:Generator_UserColumnName="CreePar" msprop:Generator_ColumnPropNameInRow="CreePar" msprop:Generator_ColumnPropNameInTable="CreeParColumn" minOccurs="0">
                <xs:simpleType>
                  <xs:restriction base="xs:string">
                    <xs:maxLength value="50" />
                  </xs:restriction>
                </xs:simpleType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name="T_JournalEvenements" msprop:Generator_TableVarName="tableT_JournalEvenements" msprop:Generator_TableClassName="T_JournalEvenementsDataTable" msprop:Generator_RowClassName="T_JournalEvenementsRow" msprop:Generator_RowChangingName="T_JournalEvenementsRowChanging" msprop:Generator_UserTableName="T_JournalEvenements" msprop:Generator_RowChangedName="T_JournalEvenementsRowChanged" msprop:Generator_TablePropName="T_JournalEvenements" msprop:Generator_RowEvArgName="T_JournalEvenementsRowChangeEvent" msprop:Generator_RowDeletingName="T_JournalEvenementsRowDeleting" msprop:Generator_RowDeletedName="T_JournalEvenementsRowDeleted" msprop:Generator_RowEvHandlerName="T_JournalEvenementsRowChangeEventHandler">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="Id_Event" msdata:ReadOnly="true" msdata:AutoIncrement="true" msprop:Generator_ColumnVarNameInTable="columnId_Event" msprop:Generator_UserColumnName="Id_Event" msprop:Generator_ColumnPropNameInRow="Id_Event" msprop:Generator_ColumnPropNameInTable="Id_EventColumn" type="xs:long" />
              <xs:element name="DateEvent" msprop:Generator_ColumnVarNameInTable="columnDateEvent" msprop:Generator_UserColumnName="DateEvent" msprop:Generator_ColumnPropNameInRow="DateEvent" msprop:Generator_ColumnPropNameInTable="DateEventColumn" type="xs:dateTime" />
              <xs:element name="TypeEvent" msprop:Generator_ColumnVarNameInTable="columnTypeEvent" msprop:Generator_UserColumnName="TypeEvent" msprop:Generator_ColumnPropNameInRow="TypeEvent" msprop:Generator_ColumnPropNameInTable="TypeEventColumn">
                <xs:simpleType>
                  <xs:restriction base="xs:string">
                    <xs:maxLength value="50" />
                  </xs:restriction>
                </xs:simpleType>
              </xs:element>
              <xs:element name="Description" msprop:Generator_ColumnVarNameInTable="columnDescription" msprop:Generator_UserColumnName="Description" msprop:Generator_ColumnPropNameInRow="Description" msprop:Generator_ColumnPropNameInTable="DescriptionColumn" type="xs:string" minOccurs="0" />
              <xs:element name="AncienneValeur" msprop:Generator_ColumnVarNameInTable="columnAncienneValeur" msprop:Generator_UserColumnName="AncienneValeur" msprop:Generator_ColumnPropNameInRow="AncienneValeur" msprop:Generator_ColumnPropNameInTable="AncienneValeurColumn" type="xs:string" minOccurs="0" />
              <xs:element name="NouvelleValeur" msprop:Generator_ColumnVarNameInTable="columnNouvelleValeur" msprop:Generator_UserColumnName="NouvelleValeur" msprop:Generator_ColumnPropNameInRow="NouvelleValeur" msprop:Generator_ColumnPropNameInTable="NouvelleValeurColumn" type="xs:string" minOccurs="0" />
              <xs:element name="Utilisateur" msprop:Generator_ColumnVarNameInTable="columnUtilisateur" msprop:Generator_UserColumnName="Utilisateur" msprop:Generator_ColumnPropNameInRow="Utilisateur" msprop:Generator_ColumnPropNameInTable="UtilisateurColumn" minOccurs="0">
                <xs:simpleType>
                  <xs:restriction base="xs:string">
                    <xs:maxLength value="50" />
                  </xs:restriction>
                </xs:simpleType>
              </xs:element>
              <xs:element name="VersionLogiciel" msprop:Generator_ColumnVarNameInTable="columnVersionLogiciel" msprop:Generator_UserColumnName="VersionLogiciel" msprop:Generator_ColumnPropNameInRow="VersionLogiciel" msprop:Generator_ColumnPropNameInTable="VersionLogicielColumn" minOccurs="0">
                <xs:simpleType>
                  <xs:restriction base="xs:string">
                    <xs:maxLength value="50" />
                  </xs:restriction>
                </xs:simpleType>
              </xs:element>
              <xs:element name="Signature" msprop:Generator_ColumnVarNameInTable="columnSignature" msprop:Generator_UserColumnName="Signature" msprop:Generator_ColumnPropNameInRow="Signature" msprop:Generator_ColumnPropNameInTable="SignatureColumn" type="xs:string" />
              <xs:element name="PreviousSignature" msprop:Generator_ColumnVarNameInTable="columnPreviousSignature" msprop:Generator_UserColumnName="PreviousSignature" msprop:Generator_ColumnPropNameInRow="PreviousSignature" msprop:Generator_ColumnPropNameInTable="PreviousSignatureColumn" type="xs:string" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
"""

with open(xsd_path, 'r') as f:
    content = f.read()

if 'name="T_Cloture"' not in content:
    # Find the end of xs:choice
    choice_end = content.find('</xs:choice>')
    if choice_end != -1:
        content = content[:choice_end] + table_defs + content[choice_end:]
        print("Injected T_Cloture and T_JournalEvenements definitions")
else:
    print("Definitions already present")

with open(xsd_path, 'w') as f:
    f.write(content)
