
import os

xsd_path = "/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/CLI/CLIDataSet.xsd"

signature_elements = """              <xs:element name="Signature" msprop:Generator_ColumnPropNameInTable="SignatureColumn" msprop:Generator_ColumnPropNameInRow="Signature" msprop:Generator_UserColumnName="Signature" msprop:Generator_ColumnVarNameInTable="columnSignature" minOccurs="0">
                <xs:simpleType>
                  <xs:restriction base="xs:string">
                    <xs:maxLength value="255" />
                  </xs:restriction>
                </xs:simpleType>
              </xs:element>
              <xs:element name="PreviousSignature" msprop:Generator_ColumnPropNameInTable="PreviousSignatureColumn" msprop:Generator_ColumnPropNameInRow="PreviousSignature" msprop:Generator_UserColumnName="PreviousSignature" msprop:Generator_ColumnVarNameInTable="columnPreviousSignature" minOccurs="0">
                <xs:simpleType>
                  <xs:restriction base="xs:string">
                    <xs:maxLength value="255" />
                  </xs:restriction>
                </xs:simpleType>
              </xs:element>
"""

with open(xsd_path, 'r') as f:
    content = f.read()

# Tables to update
tables = ["T_CommandeVente", "T_CommandeVente_Ligne", "T_Reglement", "T_Avoir"]

for table in tables:
    # Find the end of the sequence for this table
    # We look for <xs:element name="Table" ... > ... </xs:sequence>
    start_tag = f'name="{table}"'
    start_index = content.find(start_tag)
    if start_index != -1:
        # Find the next </xs:sequence> after this table starts
        seq_end_index = content.find('</xs:sequence>', start_index)
        if seq_end_index != -1:
            # Check if Signature already exists to avoid duplicates
            if f'name="Signature"' not in content[start_index:seq_end_index]:
                content = content[:seq_end_index] + signature_elements + content[seq_end_index:]
                print(f"Updated {table}")
            else:
                print(f"{table} already has Signature")

with open(xsd_path, 'w') as f:
    f.write(content)
