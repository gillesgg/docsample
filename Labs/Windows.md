# Windows installation

## Install winget tool
https://www.microsoft.com/p/app-installer/9nblggh4nns1#activetab=pivot:overviewtab

## Install Windbg
Winget install "WinDbg Preview" --force --accept-package-agreements --accept-source-agreements

## Install Windows Terminal
From cmd or PowerShell start
winget install Microsoft.WindowsTerminal -y

## Install PowerShell Core
winget install -e --id Microsoft.PowerShell

## Install Visual Studio Code
winget install -e --id Microsoft.VisualStudioCode

## Install Git
winget install -e --id Git.Git

## Install 7zip
winget install -e --id 7zip.7zip

## Install Sysinternals Suite
winget install -e --id Microsoft.Sysinternals

## Install Visual Studio 2022 Community or Professional or Enterprise
winget install -e --id Microsoft.VisualStudio.2022.Community
winget install -e --id Microsoft.VisualStudio.2022.Professional
winget install -e --id Microsoft.VisualStudio.2022.Enterprise


### Sysinternals Suite
Download from : https://download.sysinternals.com/files/SysinternalsSuite.zip
Unzip to the following folder: C:\tools\SysinternalsSuite
