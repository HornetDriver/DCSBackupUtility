# DCS Backup Utility

A lightweight Windows utility for backing up important Digital Combat Simulator (DCS) files and folders with configurable retention, optional scheduled backups, and simple restore-friendly ZIP archives.

Designed for DCS users who want a straightforward way to protect:
- Missions
- Input bindings
- Kneeboards
- Liveries
- Campaign progress
- Config files
- Mods and custom content

---

## Features

- Simple Windows desktop interface
- Select multiple folders to back up
- Configurable primary and secondary backup retention
- Automatic ZIP archive creation
- Optional Windows Scheduled Task integration
- One-click access to the README from inside the app
- Open-source and free to use

---

## Recommended Use Cases

This utility is especially useful before:
- DCS updates
- Mod installations
- Large mission edits
- Control rebinding
- Campaign progression
- Testing scripts or plugins

It can also be used as part of a broader disaster recovery strategy for:
- SSD/HDD failure
- Corrupted Saved Games folders
- Accidental deletion
- Bad mods or configuration changes

---

# Installation

1. Download the latest release.
2. Extract the application to a folder of your choice.
3. Run the executable.

No installer is required.

NOTE: Depending on Windows SmartScreen settings, unsigned applications may trigger a warning. This is normal for smaller independent open-source utilities without a commercial code-signing certificate.

---

# Basic Usage

## 1. Select Backup Source Folders

Choose the folders you want included in the backup.

Typical DCS folders include:

C:\Users\<YourUser>\Saved Games\DCS

You may also choose individual subfolders if preferred.

---

## 2. Select Backup Destination

Choose where backups should be stored.

Recommended locations:
- Secondary internal SSD
- External drive
- NAS / network storage
- Cloud-synced folder

Avoid storing backups only on the same physical drive as DCS.

---

## 3. Configure Retention

The utility supports configurable retention counts.

Example:
- Keep last 7 primary backups
- Keep last 30 secondary backups

Older backups beyond the retention limit are automatically removed.

---

## 4. Run a Backup

Click the backup button to create a ZIP archive of the selected folders.

Backup filenames typically include timestamps for easy identification.

---

# Scheduled Backups

The application can optionally create a Windows Scheduled Task to automate backups.

Typical schedules:
- Daily
- Weekly
- Before normal DCS play sessions

Recommended:
- Daily backups for active mission creators
- Weekly backups for casual users

The scheduled task runs using Windows Task Scheduler.

---

# Restoring Backups

1. Locate the desired ZIP archive.
2. Extract the contents using:
   - Windows Explorer
   - 7-Zip
   - WinRAR
3. Copy the restored files back into the appropriate DCS folders.

It is strongly recommended to restore into a temporary folder first to inspect contents before overwriting live files.

---

# Important Warning

## VERIFY YOUR BACKUPS

Creating a backup does NOT guarantee that the backup is valid.

You should periodically:
- Open backup ZIP files
- Verify files are present
- Test restoring important folders
- Confirm backup archives are not corrupted

A backup that has never been tested should never be considered fully reliable.

This is especially important before:
- DCS updates
- Windows reinstalls
- Hardware replacement
- Major mod changes

---

# Suggested Backup Targets

Common high-value DCS folders include:

Saved Games\DCS\Config\Input
Saved Games\DCS\Missions
Saved Games\DCS\Kneeboard
Saved Games\DCS\Liveries
Saved Games\DCS\Scripts
Saved Games\DCS\Mods

---

# Best Practices

- Keep multiple generations of backups
- Store at least one backup off-device
- Verify backups regularly
- Do not rely on a single storage drive
- Back up before installing mods or updating DCS
- Label backup destinations clearly

---

# Open Source

This project is intended to remain free and open-source.

Contributions, improvements, bug reports, and suggestions are welcome.

---

# Disclaimer

This software is provided "as-is" without warranty of any kind.

The author is not responsible for:
- Data loss
- Corrupted backups
- Failed restores
- Damage caused by improper use

Always maintain multiple independent backups of important data.

---

# Future Ideas

Potential future improvements may include:
- Differential/incremental backups
- Restore interface
- Backup verification
- Compression level options
- Multi-profile support
- Cloud backup integration
- Backup health reporting

---

# Acknowledgments

Created for the DCS community and mission creators who have lost one too many control bindings, missions, or Saved Games folders.

Fly safe — and back up your configs.
