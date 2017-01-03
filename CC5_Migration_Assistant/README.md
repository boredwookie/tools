# About
This project allowed me to migrate data from concrete5 into a format that can be processed by Jekyll.

# Order of Operations
- Use the Legacy Exporter plugin in CC5 to export XML and Files (https://github.com/concrete5/addon_migration_tool_legacy/issues/2)
  - You will probably have to export your site in 'chunks' - I had 200 posts and had to export by year to avoid timeouts
- Use this tool to parse the xml into pages with YAML per Jekyll spec
- Move your files to their new home in the Jekyll project structure
- Spend hours removing duplicate information, adding dates for page publication and dealing your site template

