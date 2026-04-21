
import os
import re

xsd_path = "/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/CLI/CLIDataSet.xsd"

tables_to_protect = ["T_CommandeVente", "T_CommandeVente_Ligne", "T_Reglement", "T_Avoir"]

with open(xsd_path, 'r') as f:
    content = f.read()

for table in tables_to_protect:
    # Find the TableAdapter for this table
    # Pattern: <TableAdapter ... Name="Table" ... > ... <DeleteCommand> ... </DeleteCommand> ... </TableAdapter>
    
    # We use a non-greedy search for the DeleteCommand within a TableAdapter block
    # This is tricky in regex with nested tags, so we'll do it step by step
    
    table_adapter_start = content.find(f'Name="{table}"')
    if table_adapter_start != -1:
        # Find the next </TableAdapter>
        adapter_end = content.find('</TableAdapter>', table_adapter_start)
        if adapter_end != -1:
            adapter_block = content[table_adapter_start:adapter_end]
            # Replace DeleteCommand block with nothing
            # Note: We need to be careful about the tags
            new_adapter_block = re.sub(r'<DeleteCommand>.*?</DeleteCommand>', '', adapter_block, flags=re.DOTALL)
            content = content[:table_adapter_start] + new_adapter_block + content[adapter_end:]
            print(f"Removed DeleteCommand for {table}")

with open(xsd_path, 'w') as f:
    f.write(content)
