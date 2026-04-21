
import re

kanban_path = "/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/KANBAN_NF525.md"

with open(kanban_path, 'r') as f:
    content = f.read()

# Update metrics
metrics = {
    "Tâches terminées": "21",
    "Tâches en cours": "2",
    "Conformité NF525": "65%"
}

new_content = content
for key, value in metrics.items():
    if key == "Tâches terminées":
        new_content = re.sub(fr"\| \*\*Tâches terminées\*\* \| \d+ \| 37 \|", f"| **Tâches terminées** | {value} | 37 |", new_content)
    elif key == "Tâches en cours":
        new_content = re.sub(fr"\| \*\*Tâches en cours\*\* \| \d+ \| - \|", f"| **Tâches en cours** | {value} | - |", new_content)
    elif key == "Conformité NF525":
        new_content = re.sub(fr"\| \*\*Conformité NF525\*\* \| \*\*\d+%\*\* \| 100% \|", f"| **Conformité NF525** | **{value}** | 100% |", new_content)

# Update progress text
new_content = re.sub(r"⏳ \d+%", f"⏳ {int(21/37*100)}%", new_content)

with open(kanban_path, 'w') as f:
    f.write(new_content)
print("Updated Kanban metrics")
